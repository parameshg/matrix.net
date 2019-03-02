# create public ip for nodes (not required if load balancer is available)
resource "azurerm_public_ip" "matrix" {
  count                        = "${var.scale}"
  name                         = "matrix-node-${count.index + 1}-public-ip"
  location                     = "${azurerm_resource_group.matrix.location}"
  resource_group_name          = "${azurerm_resource_group.matrix.name}"
  public_ip_address_allocation = "static"

  tags {
    environment   = "${var.environment}"
    configuration = "${var.configuration}"
  }
}

# create network security group
resource "azurerm_network_security_group" "matrix" {
  name                = "matrix-network-security-group"
  location            = "${azurerm_resource_group.matrix.location}"
  resource_group_name = "${azurerm_resource_group.matrix.name}"

  # allow HTTP traffic to public
  security_rule {
    name                       = "matrix-nodes-allow-80"
    priority                   = 4000
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "80"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  # allow HTTPS traffic to public
  security_rule {
    name                       = "matrix-nodes-allow-443"
    priority                   = 4010
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  # allow SSH traffic to whitelisted (not required if bastion host is available)
  security_rule {
    name                       = "matrix-nodes-allow-22"
    priority                   = 4020
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "22"
    source_address_prefix      = "${var.whitelist}"
    destination_address_prefix = "*"
  }

  tags {
    environment   = "${var.environment}"
    configuration = "${var.configuration}"
  }
}

# create network interface
resource "azurerm_network_interface" "matrix" {
  count                     = "${var.scale}"
  name                      = "matrix-node-${count.index + 1}-network-interface"
  location                  = "${azurerm_resource_group.matrix.location}"
  resource_group_name       = "${azurerm_resource_group.matrix.name}"
  network_security_group_id = "${azurerm_network_security_group.matrix.id}"

  ip_configuration {
    name                                      = "node-ip"
    subnet_id                                 = "${azurerm_subnet.matrix.id}"
    private_ip_address_allocation             = "dynamic"
    # comment this if load balancer is available
    public_ip_address_id                      = "${azurerm_public_ip.matrix.*.id[count.index]}"
    # uncomment this when load balancer is available
    # load_balancer_backend_address_pools_ids = ["${azurerm_lb_backend_address_pool.load_balancer_backend.id}"]
  }

  tags {
    environment   = "${var.environment}"
    configuration = "${var.configuration}"
  }
}

# create virtual machine
resource "azurerm_virtual_machine" "matrix" {
  count                            = "${var.scale}"
  name                             = "matrix-node-${count.index + 1}"
  location                         = "${azurerm_resource_group.matrix.location}"
  resource_group_name              = "${azurerm_resource_group.matrix.name}"
  network_interface_ids            = ["${azurerm_network_interface.matrix.*.id[count.index]}"]
  # 1 vCPU, 1 GB RAM, 4 GB SSD
  vm_size                          = "Standard_B2s"
  availability_set_id              = "${azurerm_availability_set.matrix.id}"
  delete_os_disk_on_termination    = true
  delete_data_disks_on_termination = true

  storage_image_reference {
    publisher = "OpenLogic"
    offer     = "CentOS"
    sku       = "7.3"
    version   = "latest"
  }

  storage_os_disk {
    name              = "matrix-node-${count.index + 1}-os-disk"
    caching           = "ReadWrite"
    create_option     = "FromImage"
    managed_disk_type = "Standard_LRS"   
  }

  storage_data_disk {
    name              = "matrix-node-${count.index + 1}-data-disk"
    managed_disk_type = "Standard_LRS"
    create_option     = "Empty"
    lun               = 0
    disk_size_gb      = "10"    
  }

  os_profile {
    computer_name  = "${var.hostname}-${count.index + 1}"
    admin_username = "centos"
  }

  os_profile_linux_config {
    disable_password_authentication = true

    ssh_keys {
       key_data = "${file("authorized_keys")}"
       path     = "/home/centos/.ssh/authorized_keys"
    }
  }

  tags {
    environment   = "${var.environment}"
    configuration = "${var.configuration}"
  }
}

# output nodes private ip addresses
output "matrix-node-private-ip" {
  value = "${azurerm_network_interface.matrix.*.private_ip_address}"
}

# output nodes public ip addresses
output "matrix-node-piblic-ip" {
  value = "${azurerm_public_ip.matrix.*.ip_address}"
}