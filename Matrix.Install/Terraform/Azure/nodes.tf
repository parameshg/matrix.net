# create network security group
resource "azurerm_network_security_group" "matrix" {
  name                = "node-network-security-group"
  location            = "${azurerm_resource_group.matrix.location}"
  resource_group_name = "${azurerm_resource_group.matrix.name}"

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}

# create network interface
resource "azurerm_network_interface" "matrix" {
  count                     = "${var.scale}"
  name                      = "node-${count.index + 1}-network-interface"
  location                  = "${azurerm_resource_group.matrix.location}"
  resource_group_name       = "${azurerm_resource_group.matrix.name}"
  network_security_group_id = "${azurerm_network_security_group.matrix.id}"

  ip_configuration {
    name                                    = "node-ip"
    subnet_id                               = "${azurerm_subnet.matrix.id}"
    private_ip_address_allocation           = "dynamic"
    load_balancer_backend_address_pools_ids = ["${azurerm_lb_backend_address_pool.matrix.id}"]
  }

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}

# create virtual machine
resource "azurerm_virtual_machine" "matrix" {
  count                            = "${var.scale}"
  name                             = "node-${count.index + 1}"
  location                         = "${azurerm_resource_group.matrix.location}"
  resource_group_name              = "${azurerm_resource_group.matrix.name}"
  network_interface_ids            = ["${azurerm_network_interface.matrix.*.id[count.index]}"]
  # 1 vCPU, 1 GB RAM, 4 GB SSD
  vm_size                          = "Standard_B1s"
  availability_set_id              = "${azurerm_availability_set.matrix.id}"
  delete_os_disk_on_termination    = true
  delete_data_disks_on_termination = true

  storage_image_reference {
    publisher = "CoreOS"
    offer     = "CoreOS"
    sku       = "Stable"
    version   = "latest"
  }

  storage_os_disk {
    name              = "node-${count.index + 1}-os-disk"
    caching           = "ReadWrite"
    create_option     = "FromImage"
    managed_disk_type = "Standard_LRS"   
  }

  storage_data_disk {
    name              = "node-${count.index + 1}-data-disk"
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
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}

# output nodes private ip addresses
output "node-private-ip" {
  value = "${azurerm_network_interface.matrix.*.private_ip_address}"
}