# create public ip address for bastion host
resource "azurerm_public_ip" "bastion" {
  name                         = "bastion-public-ip"
  location                     = "${azurerm_resource_group.matrix.location}"
  resource_group_name          = "${azurerm_resource_group.matrix.name}"
  public_ip_address_allocation = "static"

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}

# create network security group for bastion host
resource "azurerm_network_security_group" "bastion" {
  name                = "bastion-network-security-group"
  location            = "${azurerm_resource_group.matrix.location}"
  resource_group_name = "${azurerm_resource_group.matrix.name}"

  security_rule {
    name                       = "allow-ssh"
    priority                   = 1000
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "22"
    source_address_prefix      = "${var.bastion_whitelist}"
    destination_address_prefix = "*"
  }

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}

# create network interface for bastion host
resource "azurerm_network_interface" "bastion" {
  name                      = "bastion-network-interface"
  location                  = "${azurerm_resource_group.matrix.location}"
  resource_group_name       = "${azurerm_resource_group.matrix.name}"
  network_security_group_id = "${azurerm_network_security_group.bastion.id}"

  ip_configuration {
    name                                    = "bastion-ip"
    subnet_id                               = "${azurerm_subnet.matrix.id}"
    private_ip_address_allocation           = "dynamic"
    public_ip_address_id                    = "${azurerm_public_ip.bastion.id}"
  }

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}

# create  virtual machine for bastion host
resource "azurerm_virtual_machine" "bastion" {
  name                             = "bastion"
  location                         = "${azurerm_resource_group.matrix.location}"
  resource_group_name              = "${azurerm_resource_group.matrix.name}"
  network_interface_ids            = ["${azurerm_network_interface.bastion.id}"]
  # 1 vCPU, 1 GB RAM, 4 GB SSD
  vm_size                          = "Standard_B1s"
  delete_os_disk_on_termination    = true
  delete_data_disks_on_termination = true

  storage_image_reference {
    publisher = "CoreOS"
    offer     = "CoreOS"
    sku       = "Stable"
    version   = "latest"
  }

  storage_os_disk {
    name              = "bastion-os-disk"
    caching           = "ReadWrite"
    create_option     = "FromImage"
    managed_disk_type = "Standard_LRS"   
  }

  os_profile {
    computer_name  = "bastion"
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

# output bastion public ip address
output "bastion-public-ip" {
  value = "${azurerm_public_ip.bastion.ip_address}"
}