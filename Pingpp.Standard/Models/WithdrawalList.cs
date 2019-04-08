using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pingapp.Standard.Models
{
    public class WithdrawalList : Pingpp.Standard.Pingpp
    {
        [JsonProperty("total_withdrawals_amount")]
        public int TotalWithdrawalsAmount;

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public IEnumerable<Withdrawal> Data { get; set; }
    }
}