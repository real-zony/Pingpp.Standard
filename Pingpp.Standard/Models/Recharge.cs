using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Recharge : Pingpp
  {
    private const string BaseUrl = "/v1/apps/{0}/recharges";

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

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("succeeded")]
    public bool Succeeded { get; set; }

    [JsonProperty("time_succeeded")]
    public int? TimeSucceeded { get; set; }

    [JsonProperty("refunded")]
    public bool Refunded { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("from_user")]
    public string FromUser { get; set; }

    [JsonProperty("user_fee")]
    public int UserFee { get; set; }

    [JsonProperty("charge")]
    public Charge Charge { get; set; }

    [JsonProperty("balance_bonus")]
    public BalanceBonus BalanceBonus { get; set; }

    [JsonProperty("balance_transaction")]
    public string BalanceTransaction { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    public static Recharge Create(string appId, Dictionary<string, object> createParams)
    {
      return Mapper<Recharge>.MapFromJson(Requestor.DoRequest(string.Format("/v1/apps/{0}/recharges", (object) appId), "POST", createParams), (string) null);
    }

    public static Recharge Retrieve(string appId, string id)
    {
      return Mapper<Recharge>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/recharges", (object) appId), (object) id), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static RechargeList List(string appId, Dictionary<string, object> listParams = null)
    {
      return Mapper<RechargeList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/recharges", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}