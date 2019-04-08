using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Exceptions;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Charge : Pingpp
  {
    private const string BaseUrl = "/v1/charges";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("paid")]
    public bool Paid { get; set; }

    [JsonProperty("refunded")]
    public bool Refunded { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("order_no")]
    public string OrderNo { get; set; }

    [JsonProperty("client_ip")]
    public string ClientIp { get; set; }

    [JsonProperty("amount")]
    public int? Amount { get; set; }

    [JsonProperty("amount_settle")]
    public int? AmountSettle { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("subject")]
    public string Subject { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { get; set; }

    [JsonProperty("time_paid")]
    public int? TimePaid { get; set; }

    [JsonProperty("time_expire")]
    public int? TimeExpire { get; set; }

    [JsonProperty("time_settle")]
    public int? TimeSettle { get; set; }

    [JsonProperty("transaction_no")]
    public string TransactionNo { get; set; }

    [JsonProperty("refunds")]
    public RefundList Refunds { get; set; }

    [JsonProperty("amount_refunded")]
    public int? AmountRefunded { get; set; }

    [JsonProperty("failure_code")]
    public string FailureCode { get; set; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("credential")]
    public Dictionary<string, object> Credential { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("reversed")]
    public bool Reversed { get; set; }

    public static Charge Create(Dictionary<string, object> chParams)
    {
      return Mapper<Charge>.MapFromJson(Requestor.DoRequest("/v1/charges", "POST", chParams), (string) null);
    }

    public static Charge Retrieve(string id)
    {
      return Mapper<Charge>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/charges", (object) id), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static ChargeList List(Dictionary<string, object> listParams = null)
    {
      object obj;
      if (listParams == null || !listParams.TryGetValue("app", out obj))
        throw new PingppException("Please pass app[id] as param");
      Dictionary<string, string> dictionary = obj as Dictionary<string, string>;
      string str;
      if (dictionary != null && dictionary.TryGetValue("id", out str) && string.IsNullOrEmpty(str))
        throw new PingppException("Please pass app[id] as param");
      return Mapper<ChargeList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/charges", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Charge Reverse(string id, Dictionary<string, object> chParams = null)
    {
      return Mapper<Charge>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/reverse", (object) "/v1/charges", (object) id), "POST", chParams), (string) null);
    }
  }
}