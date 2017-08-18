#r "Newtonsoft.Json"
using System.Net;
using System.Text;
using Newtonsoft.Json;

public static HttpResponseMessage Run(HttpRequestMessage req, Inventory inventory, string productid, TraceWriter log)
{

  var json = JsonConvert.SerializeObject(inventory);

  return new HttpResponseMessage(HttpStatusCode.OK) 
  {
    Content = new StringContent(json, Encoding.UTF8, "application/json")
  };
}

public class Inventory
{
  public string Name { get; set; }
  public int OnHand { get; set; }
  public int Ordered { get; set; }
}