#r "Microsoft.WindowsAzure.Storage"
#r "Newtonsoft.Json"
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, Inventory inventoryStatus, TraceWriter log)
{
  log.Info("inventory table initializtion triggered");

  //Do whatever you want to do, for example call a webhook with JSON payload
  if (inventoryStatus == null) {
    log.Info("initializing inventory table");
    var storageAccount = CloudStorageAccount.Parse(System.Environment.GetEnvironmentVariable("WEBSITE_CONTENTAZUREFILECONNECTIONSTRING", EnvironmentVariableTarget.Process));  
    var tableClient = storageAccount.CreateCloudTableClient();  
    var cloudTable = tableClient.GetTableReference("inventory");  
    cloudTable.CreateIfNotExists();

    // init the initial records from file and insert then in a batch
    List<Inventory> initInventory = JsonConvert.DeserializeObject<List<Inventory>>(File.ReadAllText(@"D:\home\site\wwwroot\initInventory\initinventory.json"));
    TableBatchOperation batchOperation = new TableBatchOperation();
    foreach(Inventory item in initInventory) {
      batchOperation.InsertOrReplace(item);
    }

    cloudTable.ExecuteBatch(batchOperation);
  } else {
    log.Info("inventory table already initialized");
  }

   //Send back an empty template as JSON code, as answer to the original GET
   var template = @"{'$schema': 'https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#', 'contentVersion': '1.0.0.0', 'parameters': {}, 'variables': {}, 'resources': []}";
   HttpResponseMessage myResponse = req.CreateResponse(HttpStatusCode.OK);
   myResponse.Content = new StringContent(template, System.Text.Encoding.UTF8, "application/json");
   return myResponse;
}

public class Inventory : TableEntity
{
  public string Name { get; set; }
  public int OnHand { get; set; }
  public int Ordered { get; set; }
}