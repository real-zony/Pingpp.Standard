using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class RoyaltySettlement : Pingpp
  {
    public const string BaseUrl = "/v1/royalty_settlements";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("payer_app")]
    public string PayerApp { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("method")]
    public string Method { get; set; }

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("amount_succeeded")]
    public int AmountSucceeded { get; set; }

    [JsonProperty("amount_failed")]
    public int AmountFailed { get; set; }

    [JsonProperty("amount_canceled")]
    public int AmountCanceled { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("count_succeeded")]
    public int CountSucceeded { get; set; }

    [JsonProperty("count_failed")]
    public int CountFailed { get; set; }

    [JsonProperty("count_canceled")]
    public int CountCanceled { get; set; }

    [JsonProperty("time_finished")]
    public int? TimeFinished { get; set; }

    [JsonProperty("fee")]
    public int Fee { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("operation_url")]
    public string OperationUrl { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("royalty_transactions")]
    public RoyaltyTransactionList RoyaltyTransaction { get; set; }

    public static RoyaltySettlement Create(Dictionary<string, object> param)
    {
      return Mapper<RoyaltySettlement>.MapFromJson(Requestor.DoRequest("/v1/royalty_settlements", "POST", param), (string) null);
    }

    public static RoyaltySettlement Retrieve(string royaltySettlementId)
    {
      return Mapper<RoyaltySettlement>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalty_settlements", (object) royaltySettlementId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static RoyaltySettlement Update(
      string royaltySettlementId,
      Dictionary<string, object> param)
    {
      return Mapper<RoyaltySettlement>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalty_settlements", (object) royaltySettlementId), "PUT", param), (string) null);
    }

    public static RoyaltySettlementList List(
      Dictionary<string, object> listParam = null)
    {
      return Mapper<RoyaltySettlementList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/royalty_settlements", Requestor.CreateQuery(listParam)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}