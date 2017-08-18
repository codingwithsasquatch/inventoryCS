# Inventory - C<span>#</span>

[![Deploy to Azure](https://azuredeploy.net/deploybutton.svg)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fcodingwithsasquatch%2FinventoryCS%2Fmaster%2Fazuredeploy.json)

This is a simple Inventory REST API that responds with the inventory status of the a particular item.  The details are stored in an Azure Storage Table called "inventory" in th following format
| field | value |
| --- | --- |
| PartitionKey | "products" |
| RowKey | the productid |
| Name | the product name |
| OnHand | quantity of items on hand |
| Ordered | the quantity of items that have been ordered |

To initialize the data please either manually run the initInventory function or trigger it using a web browser

## Learn more

<TODO> Documentation