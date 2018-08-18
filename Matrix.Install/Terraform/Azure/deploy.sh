#!/bin/sh
echo $0 $1 $2 $3 $4 $5 $6 $7 $8 $9
terraform init -backend-config access_key=$1
terraform apply -auto-approve -var azure_subscription_id=$2 -var azure_tenant_id=$3 -var azure_client_id=$4 -var azure_client_secret=$5 -var environment=$6 -var config=$7 -var platform_region=$8 -var platform_resource_group=$9