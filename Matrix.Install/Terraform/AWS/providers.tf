provider "aws" {
  access_key = "${var.access_key_id}"
  secret_key = "${var.secret_access_key}"
  region     = "${var.region}"
  version    = "~> 1.31"
}