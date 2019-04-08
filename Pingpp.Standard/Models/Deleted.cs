using Newtonsoft.Json;

namespace Pingpp.Standard.Models
{
    public class Deleted : Pingpp
    {
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}