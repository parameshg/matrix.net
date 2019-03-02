# create public ip for load balancer
resource "azurerm_public_ip" "load_balancer" {
  name                         = "load-balancer-public-ip"
  location                     = "${azurerm_resource_group.matrix.location}"
  resource_group_name          = "${azurerm_resource_group.matrix.name}"
  public_ip_address_allocation = "static"
}

# create load balancer
resource "azurerm_lb" "matrix" {
  name                = "load-balancer"
  location            = "${azurerm_resource_group.matrix.location}"
  resource_group_name = "${azurerm_resource_group.matrix.name}"

  frontend_ip_configuration {
    name                 = "load-balancer-rules"
    public_ip_address_id = "${azurerm_public_ip.load_balancer.id}"
  }
}

# add rule for general HTTP traffic
resource "azurerm_lb_rule" "load_balancer_80_rule" {
  resource_group_name            = "${azurerm_resource_group.matrix.name}"
  loadbalancer_id                = "${azurerm_lb.matrix.id}"
  name                           = "load-balancer-80-rule"
  protocol                       = "Tcp"
  frontend_port                  = 80
  backend_port                   = 80
  frontend_ip_configuration_name = "load-balancer-rules"
}

# add rule for general HTTPS traffic
resource "azurerm_lb_rule" "load_balancer_443_rule" {
  resource_group_name            = "${azurerm_resource_group.matrix.name}"
  loadbalancer_id                = "${azurerm_lb.matrix.id}"
  name                           = "load-balancer-443-rule"
  protocol                       = "Tcp"
  frontend_port                  = 443
  backend_port                   = 443
  frontend_ip_configuration_name = "load-balancer-rules"
}

#  add rule for api HTTPS traffic via api gateway (Kong)
resource "azurerm_lb_rule" "load_balancer_8443_rule" {
  resource_group_name            = "${azurerm_resource_group.matrix.name}"
  loadbalancer_id                = "${azurerm_lb.matrix.id}"
  name                           = "load-balancer-8443-rule"
  protocol                       = "Tcp"
  frontend_port                  = 8443
  backend_port                   = 8443
  frontend_ip_configuration_name = "load-balancer-rules"
}

# create load balancer backend pool
resource "azurerm_lb_backend_address_pool" "matrix" {
  resource_group_name = "${azurerm_resource_group.matrix.name}"
  loadbalancer_id     = "${azurerm_lb.matrix.id}"
  name                = "load-balancer-backend"
}

# output public ip address of the load balancer
output "load-balancer-public-ip" {
  value = "${azurerm_public_ip.load_balancer.ip_address}"
}