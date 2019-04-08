using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pingpp.Standard.Models
{
    public class BalanceTransferList : Pingpp
    {
        [JsonProperty("object")]
        public string Object { set; get; }

        [JsonProperty("has_more")]
        public bool HasMore { set; get; }

        [JsonProperty("url")]
        public string Url { set; get; }

        [JsonProperty("data")]
        public IEnumerable<BalanceTransfer> Data { get; set; }
    }
}