using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Royalty : Pingpp
  {
    public const string BaseUrl = "/v1/royalties";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("payer_app")]
    public string PayerApp { get; set; }

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("method")]
    public string Method { get; set; }

    [JsonProperty("recipient_app")]
    public string RecipientApp { get; set; }

    [JsonProperty("royalty_transaction")]
    public string RoyaltyTransaction { get; set; }

    [JsonProperty("time_settled")]
    public int? TimeSettled { get; set; }

    [JsonProperty("settle_account")]
    public string SettleAccount { get; set; }

    [JsonProperty("source_app")]
    public string SourceApp { get; set; }

    [JsonProperty("source_url")]
    public string SourceUrl { get; set; }

    [JsonProperty("source_no")]
    public string SourceNo { get; set; }

    [JsonProperty("source_user")]
    public string SourceUser { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("royalty_settlement")]
    public string RoyaltySettlement { get; set; }

    public static RoyaltyList Update(Dictionary<string, object> param)
    {
      return Mapper<RoyaltyList>.MapFromJson(Requestor.DoRequest("/v1/royalties", "PUT", param), (string) null);
    }

    public static RoyaltyList List(Dictionary<string, object> listParam = null)
    {
      return Mapper<RoyaltyList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/royalties", Requestor.CreateQuery(listParam)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Royalty Retrieve(string royaltyId)
    {
      return Mapper<Royalty>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalties", (object) royaltyId), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}