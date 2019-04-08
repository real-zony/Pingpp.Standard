using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class RedEnvelope : Pingpp
  {
    private const string BaseUrl = "/v1/red_envelopes";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("received")]
    public int? Received { get; set; }

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

    [JsonProperty("transaction_no")]
    public string TransactionNo { get; set; }

    [JsonProperty("amount")]
    public int? Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    [JsonProperty("subject")]
    public string Subject { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { get; set; }

    [JsonProperty("failure_code")]
    public string FailureCode { get; set; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    public static RedEnvelope Create(Dictionary<string, object> redParams)
    {
      return Mapper<RedEnvelope>.MapFromJson(Requestor.DoRequest("/v1/red_envelopes", "POST", redParams), (string) null);
    }

    public static RedEnvelope Retrieve(string redId)
    {
      return Mapper<RedEnvelope>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/red_envelopes", (object) redId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static RedEnvelopeList List(Dictionary<string, object> listParams = null)
    {
      return Mapper<RedEnvelopeList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/red_envelopes", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}