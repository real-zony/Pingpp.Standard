using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Models;
using Pingpp.Standard.Net;

namespace Pingapp.Standard.Models
{
public class BatchWithdrawal : Pingpp.Standard.Pingpp
  {
    private const string BaseUrl = "/v1/apps";

    [JsonProperty("id")]
    public string Id { set; get; }

    [JsonProperty("object")]
    public string Object { set; get; }

    [JsonProperty("app")]
    public string App { set; get; }

    [JsonProperty("created")]
    public int? Created { set; get; }

    [JsonProperty("livemode")]
    public bool Livemode { set; get; }

    [JsonProperty("amount")]
    public int? Amount { set; get; }

    [JsonProperty("amount_succeeded")]
    public int? AmountSucceeded { set; get; }

    [JsonProperty("amount_failed")]
    public int? AmountFailed { set; get; }

    [JsonProperty("amount_canceled")]
    public int? AmountCanceled { set; get; }

    public int Count { set; get; }

    [JsonProperty("count_succeeded")]
    public int CountSucceeded { set; get; }

    [JsonProperty("count_failed")]
    public int CountFailed { set; get; }

    [JsonProperty("count_canceled")]
    public int CountCanceled { set; get; }

    [JsonProperty("fee")]
    public int? Fee { set; get; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { set; get; }

    [JsonProperty("operation_url")]
    public string OperationUrl { set; get; }

    [JsonProperty("source")]
    public string Source { set; get; }

    [JsonProperty("status")]
    public string Status { set; get; }

    [JsonProperty("user_fee")]
    public int? UserFee { set; get; }

    [JsonProperty("withdrawals")]
    public WithdrawalList Withdrawals { set; get; }

    [JsonProperty("time_finished")]
    public string TimeFinished { set; get; }

    public static BatchWithdrawal Create(
      string appId,
      Dictionary<string, object> batchwrParams)
    {
      return Mapper<BatchWithdrawal>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/batch_withdrawals", (object) "/v1/apps", (object) appId), "POST", batchwrParams), (string) null);
    }

    public static BatchWithdrawal Retrieve(string appId, string batchWithdrawalId)
    {
      return Mapper<BatchWithdrawal>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/batch_withdrawals/{2}", (object) "/v1/apps", (object) appId, (object) batchWithdrawalId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static BatchWithdrawalList List(
      string appId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<BatchWithdrawalList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/batch_withdrawals", (object) "/v1/apps", (object) appId), Requestor.CreateQuery(listParams)), "GET", listParams), (string) null);
    }
  }
}