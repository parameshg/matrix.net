# access_key is passed as arguments as backend configuration does not support string interpolation
# terraform init -backend-config="access_key=<STORAGE-ACCOUNT-ACCESS-KEY>"

terraform {
  backend "s3" {
    bucket  = "matrix"
    key     = "matrix.tfstate"
    region  = "us-west-2"   
  }
}