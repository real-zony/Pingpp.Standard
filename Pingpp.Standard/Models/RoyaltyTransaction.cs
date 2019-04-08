using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class RoyaltyTransaction : Pingpp
    {
        public const string BaseUrl = "/v1/royalty_transactions";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("settle_account")]
        public string SettleAccount { get; set; }

        [JsonProperty("source_user")]
        public string SourceUser { get; set; }

        [JsonProperty("recipient_app")]
        public string RecipientApp { get; set; }

        [JsonProperty("royalty_settlement")]
        public string RoyaltySettlement { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("failure_msg")]
        public string FailureMsg { get; set; }

        [JsonProperty("transfer")]
        public string Transfer { get; set; }

        public static RoyaltyTransaction Retrieve(string royaltyTransactionId)
        {
            return Mapper<RoyaltyTransaction>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalty_transactions", (object) royaltyTransactionId), "GET", (Dictionary<string, object>) null), (string) null);
        }

        public static RoyaltyTransactionList List(
            Dictionary<string, object> listParam = null)
        {
            return Mapper<RoyaltyTransactionList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/royalty_transactions", Requestor.CreateQuery(listParam)), "GET", (Dictionary<string, object>) null), (string) null);
        }
    }
}