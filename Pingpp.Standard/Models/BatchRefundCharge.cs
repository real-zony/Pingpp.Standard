using Newtonsoft.Json;

namespace Pingpp.Standard.Models
{
    public class BatchRefundCharge
    {
        [JsonProperty("charge")]
        public string Charge { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("funding_source")]
        public string FundingSource { get; set; }
    }
}