using Newtonsoft.Json;

namespace Pingapp.Standard.Utils
{
    internal class WxLiteOauthResult
    {
        [JsonProperty("openid")]
        public string Openid { get; set; }

        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        [JsonProperty("unionid")]
        public string Unionid { get; set; }
    }
}