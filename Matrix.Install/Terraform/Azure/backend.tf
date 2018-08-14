# access_key is passed as arguments as backend configuration does not support string interpolation
# terraform init -backend-config="access_key=<STORAGE-ACCOUNT-ACCESS-KEY>"

terraform {
  backend "azurerm" {
    storage_account_name = "param"
    container_name       = "terraform"
    key                  = "matrix.tfstate"
    environment          = "public"
  }
}