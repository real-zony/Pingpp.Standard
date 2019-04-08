using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class BalanceBonus : Pingpp
  {
    private const string BaseUrl = "/v1/apps/{0}/balance_bonuses";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("paid")]
    public bool Paid { get; set; }

    [JsonProperty("refunded")]
    public bool Refunded { get; set; }

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("amount_refunded")]
    public int AmountRefunded { get; set; }

    [JsonProperty("order_no")]
    public string OrderNo { get; set; }

    [JsonProperty("time_paid")]
    public int? TimePaid { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("balance_transaction")]
    public string BalanceTransaction { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    public static BalanceBonus Create(
      string appId,
      Dictionary<string, object> bonusParams)
    {
      return Mapper<BalanceBonus>.MapFromJson(Requestor.DoRequest(string.Format("/v1/apps/{0}/balance_bonuses", (object) appId), "POST", bonusParams), (string) null);
    }

    public static BalanceBonus Retrieve(string appId, string balanceBonusId)
    {
      return Mapper<BalanceBonus>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/balance_bonuses", (object) appId), (object) balanceBonusId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static BalanceBonusList List(
      string appId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<BalanceBonusList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/balance_bonuses", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}