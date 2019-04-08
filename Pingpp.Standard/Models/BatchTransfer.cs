using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class BatchTransfer : Pingpp
  {
    [JsonProperty("failure_msg")]
    public string FailureMsg;
    [JsonProperty("time_succeeded")]
    public string TimeSucceeded;
    private const string BaseUrl = "/v1/batch_transfers";

    [JsonProperty("id")]
    public string Id { set; get; }

    [JsonProperty("object")]
    public string Object { set; get; }

    [JsonProperty("app")]
    public string App { set; get; }

    [JsonProperty("amount")]
    public int? Amount { set; get; }

    [JsonProperty("batch_no")]
    public string BatchNo { set; get; }

    [JsonProperty("channel")]
    public string Channel { set; get; }

    [JsonProperty("currency")]
    public string Currency { set; get; }

    [JsonProperty("created")]
    public int? Created { set; get; }

    [JsonProperty("description")]
    public string Description { set; get; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { set; get; }

    [JsonProperty("fee")]
    public int Fee { set; get; }

    [JsonProperty("livemode")]
    public bool Livemode { set; get; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> MetaData { set; get; }

    [JsonProperty("recipients")]
    public List<Dictionary<string, object>> RecipientsList { set; get; }

    [JsonProperty("status")]
    public string Status { set; get; }

    [JsonProperty("type")]
    public string Type { set; get; }

    public static BatchTransfer Create(Dictionary<string, object> btParams)
    {
      return Mapper<BatchTransfer>.MapFromJson(Requestor.DoRequest("/v1/batch_transfers", "POST", btParams), (string) null);
    }

    public static BatchTransfer Retrieve(string batchTransferNo)
    {
      return Mapper<BatchTransfer>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/batch_transfers", (object) batchTransferNo), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static BatchTransferList List(Dictionary<string, object> btParams)
    {
      return Mapper<BatchTransferList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/batch_transfers", Requestor.CreateQuery(btParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}