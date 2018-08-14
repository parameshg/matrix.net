# add azure provider
provider "azurerm" {
  version = ">= 1.11"
}

# add aws provider
provider "aws" {
  access_key = "${var.aws_access_key_id}"
  secret_key = "${var.aws_secret_access_key}"
  region     = "${var.aws_region}"
  version    = "~> 1.31"
}