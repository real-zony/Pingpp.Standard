using Newtonsoft.Json;

namespace Pingpp.Standard.Models
{
    public class DeletedSubAppChannel : Pingpp
    {
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }
    }
}