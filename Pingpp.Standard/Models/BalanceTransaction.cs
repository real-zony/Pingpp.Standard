using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class BalanceTransaction : Pingpp
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

        [JsonProperty("available_balance")]
        public int? AvailableBalance { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public static BalanceTransaction Retrieve(string appId, string txnId)
        {
            return Mapper<BalanceTransaction>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/balance_transactions/{2}", (object) "/v1/apps", (object) appId, (object) txnId), "GET", (Dictionary<string, object>) null), (string) null);
        }

        public static BalanceTransactionList List(
            string appId,
            Dictionary<string, object> listParams = null)
        {
            return Mapper<BalanceTransactionList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/balance_transactions", (object) "/v1/apps", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
        }
    }
}