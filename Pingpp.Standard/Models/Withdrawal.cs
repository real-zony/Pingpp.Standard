using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingapp.Standard.Models
{
    public class Withdrawal : Pingpp.Standard.Pingpp
  {
    private const string BaseUrl = "/v1/apps";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("amount")]
    public int? Amount { get; set; }

    [JsonProperty("asset_transaction")]
    public string AssetTransaction { get; set; }

    [JsonProperty("balance_transaction")]
    public string BalanceTransaction { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { get; set; }

    [JsonProperty("fee")]
    public int? Fee { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("order_no")]
    public string OrderNo { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("time_canceled")]
    public int? TimeCanceled { get; set; }

    [JsonProperty("time_succeeded")]
    public int? TimeSucceeded { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("user_fee")]
    public int? UserFee { get; set; }

    [JsonProperty("channel")]
    public string Channel { set; get; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { set; get; }

    [JsonProperty("operation_url")]
    public string OperationUrl { set; get; }

    [JsonProperty("settle_account")]
    public string SettleAccount { get; set; }

    public static Withdrawal Request(string appId, Dictionary<string, object> wdParams)
    {
      return Mapper<Withdrawal>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/withdrawals", (object) "/v1/apps", (object) appId), "POST", wdParams), (string) null);
    }

    public static Withdrawal Cancel(string appId, string wdId)
    {
      return Mapper<Withdrawal>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/withdrawals/{2}", (object) "/v1/apps", (object) appId, (object) wdId), "PUT", new Dictionary<string, object>()
      {
        {
          "status",
          (object) "canceled"
        }
      }), (string) null);
    }

    public static Withdrawal Confirm(string appId, string wdId)
    {
      return Mapper<Withdrawal>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/withdrawals/{2}", (object) "/v1/apps", (object) appId, (object) wdId), "PUT", new Dictionary<string, object>()
      {
        {
          "status",
          (object) "pending"
        }
      }), (string) null);
    }

    public static WithdrawalList List(
      string appId,
      Dictionary<string, object> listParams)
    {
      return Mapper<WithdrawalList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/withdrawals", (object) "/v1/apps", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Withdrawal Retrieve(string appId, string wdId)
    {
      return Mapper<Withdrawal>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/withdrawals/{2}", (object) "/v1/apps", (object) appId, (object) wdId), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}