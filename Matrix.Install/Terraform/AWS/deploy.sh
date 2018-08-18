#!/bin/sh
echo $0 $1 $2 $3 $4 $5 $6 $7
terraform init -backend-config access_key=$1
terraform apply -auto-approve -var aws_access_key_id=$2 -var aws_secret_access_key=$3 -var environment=$4 -var config=$5 -var platform_region=$6 -var platform_resource_group=$7