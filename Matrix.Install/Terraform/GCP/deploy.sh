#!/bin/sh
echo $0 $1 $2 $3 $4 $5 $6
terraform init -backend-config access_key=$1
terraform apply -auto-approve -var gcp-service-account-key=$2  -var environment=$3 -var config=$4 -var platform_region=$5 -var platform_resource_group=$6