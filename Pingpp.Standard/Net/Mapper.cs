using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pingpp.Standard.Exceptions;

namespace Pingpp.Standard.Net
{
    public static class Mapper<T>
    {
        public static List<T> MapCollectionFromJson(string json, string data = "data")
        {
            if (string.IsNullOrEmpty(json))
                throw new PingppException("No json received");
            return JObject.Parse(json).SelectToken(data).Select(tkn => MapFromJson(tkn.ToString())).ToList();
        }

        public static T MapFromJson(string json, string parentToken = null)
        {
            return JsonConvert.DeserializeObject<T>(string.IsNullOrEmpty(parentToken) ? json : JObject.Parse(json).SelectToken(parentToken).ToString());
        }
    }
}