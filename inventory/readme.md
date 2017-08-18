# Inventory - C<span>#</span>

This is a simple Inventory REST API that responds with the inventory status of the a particular item.  The details are stored in an Azure Storage Table called "inventory" in th following format

| PartitionKey | "products" |
| ------- | -------- | ------ |
| RowKey | the productid |
| Name | the product name |
| OnHand | quantity of items on hand |
| Ordered | the quantity of items that have been ordered |

## Learn more

<TODO> Documentation