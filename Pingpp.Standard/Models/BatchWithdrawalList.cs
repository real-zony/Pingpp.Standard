using System.Collections.Generic;
using Newtonsoft.Json;
using Pingapp.Standard.Models;

namespace Pingpp.Standard.Models
{
    public class BatchWithdrawalList : Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public IEnumerable<BatchWithdrawal> Data { get; set; }
    }
}