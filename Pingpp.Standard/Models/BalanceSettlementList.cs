using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pingpp.Standard.Models
{
    public class BalanceSettlementList : Pingpp
    {
        [JsonProperty("object")]
        public string Object { set; get; }

        [JsonProperty("has_more")]
        public bool HasMore { set; get; }

        [JsonProperty("url")]
        public string Url { set; get; }

        [JsonProperty("data")]
        public IEnumerable<BalanceSettlement> Data { get; set; }
    }
}