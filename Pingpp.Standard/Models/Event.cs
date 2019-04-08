using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class Event : Pingpp
    {
        private const string BaseUrl = "/v1/events";

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

        [JsonProperty("pending_webhooks")]
        public int? PendingWebhooks { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }

        public static Event Retrieve(string id)
        {
            return Mapper<Event>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/events", (object) id), "Get", (Dictionary<string, object>) null), (string) null);
        }
    }
}