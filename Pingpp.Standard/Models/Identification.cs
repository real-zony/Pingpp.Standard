using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class Identification : Pingpp
    {
        private const string BaseUrl = "/v1/identification";

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("result_code")]
        public string ResultCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("paid")]
        public bool Paid { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

        public static Identification Identify(Dictionary<string, object> iParams)
        {
            return Mapper<Identification>.MapFromJson(Requestor.DoRequest("/v1/identification", "POST", iParams), (string) null);
        }
    }
}