using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class BalanceTransfer : Pingpp
  {
    private const string BaseUrl = "/v1/apps/{0}/balance_transfers";

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

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("user_fee")]
    public int UserFee { get; set; }

    [JsonProperty("recipient")]
    public string Recipient { get; set; }

    [JsonProperty("user_balance_transaction")]
    public string UserBalanceTransaction { get; set; }

    [JsonProperty("recipient_balance_transaction")]
    public string RecipientBalanceTransaction { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    public static BalanceTransfer Create(
      string appId,
      Dictionary<string, object> btParams)
    {
      return Mapper<BalanceTransfer>.MapFromJson(Requestor.DoRequest(string.Format("/v1/apps/{0}/balance_transfers", (object) appId), "POST", btParams), (string) null);
    }

    public static BalanceTransfer Retrieve(string appId, string balanceTransferId)
    {
      return Mapper<BalanceTransfer>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/balance_transfers", (object) appId), (object) balanceTransferId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static BalanceTransferList List(
      string appId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<BalanceTransferList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/balance_transfers", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}