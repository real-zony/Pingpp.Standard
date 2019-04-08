using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Refund : Pingpp
  {
    private const string BaseUrl = "/v1/charges";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("order_no")]
    public string OrderNo { get; set; }

    [JsonProperty("amount")]
    public int? Amount { get; set; }

    [JsonProperty("succeed")]
    public bool Succeed { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("time_succeed")]
    public int? TimeSucceed { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("failure_code")]
    public string FailureCode { get; set; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("charge")]
    public string Charge { get; set; }

    [JsonProperty("charge_order_no")]
    public string ChargeOrderNo { get; set; }

    [JsonProperty("transaction_no")]
    public string TransactionNo { get; set; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { get; set; }

    public static Refund Create(string id, Dictionary<string, object> reParams)
    {
      return Mapper<Refund>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/refunds", (object) "/v1/charges", (object) id), "POST", reParams), (string) null);
    }

    public static Refund Retrieve(string chId, string reId)
    {
      return Mapper<Refund>.MapFromJson(Requestor.DoRequest(string.Format("/v1/charges/{0}/refunds/{1}", (object) chId, (object) reId), "Get", (Dictionary<string, object>) null), (string) null);
    }

    public static RefundList List(string id, Dictionary<string, object> listParams = null)
    {
      return Mapper<RefundList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/charges/{0}/refunds", (object) id), Requestor.CreateQuery(listParams)), "Get", (Dictionary<string, object>) null), (string) null);
    }
  }
}