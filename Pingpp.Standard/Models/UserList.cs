using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pingapp.Standard.Models
{
    public class UserList : Pingpp.Standard.Pingpp
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public IEnumerable<User> Data { get; set; }
    }
}