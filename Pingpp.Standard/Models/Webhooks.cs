using Newtonsoft.Json.Linq;
using Pingpp.Standard.Exceptions;
using Pingpp.Standard.Models;
using Pingpp.Standard.Net;

namespace Pingapp.Standard.Models
{
    public class Webhooks : Pingpp.Standard.Pingpp
    {
        public static Event ParseWebhook(string events)
        {
            JToken jtoken = JObject.Parse(events).SelectToken("object");
            if (events.Contains("object") && ((object) jtoken).ToString().Equals("event"))
                return Mapper<Event>.MapFromJson(events, (string) null);
            throw new PingppException("It isn't a json string of event object");
        }
    }
}