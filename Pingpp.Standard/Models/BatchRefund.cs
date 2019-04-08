using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class BatchRefund : Pingpp
    {
        private const string BaseUrl = "/v1/batch_refunds";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("batch_no")]
        public string BatchNo { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("charges")]
        public List<BatchRefundCharge> BatchRefundCharge { get; set; }

        [JsonProperty("refunds")]
        public RefundList Refunds { get; set; }

        [JsonProperty("refund_url")]
        public string RefundUrl { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time_succeeded")]
        public string TimeSucceeded { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        public static BatchRefund Create(Dictionary<string, object> bfParams)
        {
            return Mapper<BatchRefund>.MapFromJson(Requestor.DoRequest("/v1/batch_refunds", "POST", bfParams), (string) null);
        }

        public static BatchRefund Retrieve(string batchRefundId)
        {
            return Mapper<BatchRefund>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/batch_refunds", (object) batchRefundId), "GET", (Dictionary<string, object>) null), (string) null);
        }

        public static BatchRefundList List(Dictionary<string, object> listParams = null)
        {
            return Mapper<BatchRefundList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/batch_refunds", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
        }
    }
}