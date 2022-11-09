# Define the region and resource group name to deploy
region=japaneast
resourceGroupName=$1
httpTriggerFunctionName="SampleHttpFunction"

# Create a resource group
az group create \
    --location $region \
    --resource-group $resourceGroupName

# Deploy the Bicep template
functionAppName=`az deployment group create \
    --resource-group $resourceGroupName \
    --template-file deploy.bicep \
    --query "properties.outputs.functionAppName.value" \
    --output tsv`

# Deploy functions
func azure functionapp publish $functionAppName --csharp

# Get a function key to access
code=`az functionapp function keys list \
    --resource-group $resourceGroupName \
    --name $functionAppName \
    --function-name "$httpTriggerFunctionName" \
    --query "default" \
    --output tsv`

# Show an URL of the function for a Webhook URL of LINE Messaging API
echo "You can access deployed a Http trigger function using the following URL:"
echo https://$functionAppName.azurewebsites.net/api/$httpTriggerFunctionName?code=$code