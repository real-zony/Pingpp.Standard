using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class Transfer : Pingpp
  {
    private const string BaseUrl = "/v1/transfers";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("time_transferred")]
    public int? TimeTransferred { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("order_no")]
    public string OrderNo { get; set; }

    [JsonProperty("amount")]
    public int? Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("transaction_no")]
    public string TransactionNo { get; set; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { get; set; }

    [JsonProperty("failure_code")]
    public string FailureCode { get; set; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    public static Transfer Create(Dictionary<string, object> trParams)
    {
      return Mapper<Transfer>.MapFromJson(Requestor.DoRequest("/v1/transfers", "POST", trParams), (string) null);
    }

    public static Transfer Retrieve(string trId)
    {
      return Mapper<Transfer>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/transfers", (object) trId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static TransferList List(Dictionary<string, object> listParams = null)
    {
      return Mapper<TransferList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/transfers", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}