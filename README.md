# Azure Functions の最低限の環境の構築

## 必要な環境
- [Azure CLI](https://docs.microsoft.com/ja-jp/cli/azure/install-azure-cli)
- [Azure Bicep](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/bicep/install)
- [.NET 6.0](https://dotnet.microsoft.com/ja-jp/download/dotnet/6.0)
- [Azure Functions Core Tools ](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-run-local)

## デプロイ方法

Azure CLI で Azure テナントへログインし、使用するサブスクリプションを選択します。
```bash
az login
az account set --subscription "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

> 参考：[Azure CLI を使用して Azure サブスクリプションを管理する方法](https://learn.microsoft.com/ja-jp/cli/azure/manage-azure-subscriptions-azure-cli)

環境を構築するために、```deploy.sh```スクリプトを実行します。
```bash
./deploy.sh [リソースグループ名]
# 例： ./deploy.sh rg-azfunc-sample
```
