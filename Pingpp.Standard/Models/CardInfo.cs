using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class CardInfo : Pingpp
    {
        private const string BaseUrl = "/v1/card_info";

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("card_bin")]
        public string CardBin { get; set; }

        [JsonProperty("card_type")]
        public int CardType { get; set; }

        [JsonProperty("open_bank_code")]
        public string OpenBankCode { get; set; }

        [JsonProperty("open_bank")]
        public string OpenBank { get; set; }

        [JsonProperty("support_channels")]
        public List<string> SupportChannels { get; set; }

        public static CardInfo Query(Dictionary<string, object> Params)
        {
            return Mapper<CardInfo>.MapFromJson(Requestor.DoRequest("/v1/card_info", "POST", Params), (string) null);
        }
    }
}