using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class BalanceSettlement : Pingpp
  {
    private const string BaseUrl = "/v1/apps/{0}/balance_settlements";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("amount_refunded")]
    public int AmountRefunded { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("charge")]
    public string Charge { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { get; set; }

    [JsonProperty("refunded")]
    public bool Refunded { get; set; }

    [JsonProperty("order_no")]
    public string OrderNo { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("time_credited")]
    public int TimeCredited { get; set; }

    [JsonProperty("time_succeeded")]
    public int TimeSucceeded { get; set; }

    [JsonProperty("transaction_no")]
    public string TransactionNo { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("user_fee")]
    public int UserFee { get; set; }

    public static BalanceSettlement Retrieve(
      string appId,
      string balanceSettlementId)
    {
      return Mapper<BalanceSettlement>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/balance_settlements", (object) appId), (object) balanceSettlementId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static BalanceSettlementList List(
      string appId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<BalanceSettlementList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/balance_settlements", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}