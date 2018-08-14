# create resource group
resource "azurerm_resource_group" "matrix" {
  name     = "${var.resource_group}"
  location = "${var.region}"

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }  
}

# create virtual network
resource "azurerm_virtual_network" "matrix" {
  name                = "network"
  address_space       = ["${var.network_address}"]
  location            = "${azurerm_resource_group.matrix.location}"
  resource_group_name = "${azurerm_resource_group.matrix.name}"

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }  
}

# create network subnet
resource "azurerm_subnet" "matrix" {
  name                 = "subnet"
  resource_group_name  = "${azurerm_resource_group.matrix.name}"
  virtual_network_name = "${azurerm_virtual_network.matrix.name}"
  address_prefix       = "${var.network_subnet}"
}

# create availability set for nodes
resource "azurerm_availability_set" "matrix" {
  name                         = "nodes"
  location                     = "${azurerm_resource_group.matrix.location}"
  resource_group_name          = "${azurerm_resource_group.matrix.name}"
  managed                      = true
  platform_fault_domain_count  = 1
  platform_update_domain_count = 1

  tags {
    environment = "${var.environment}"
    config      = "${var.config}"
  }
}