using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class SubAppChannel : Pingpp
  {
    [JsonProperty("params")]
    public Dictionary<string, object> Params;
    public const string BaseUrl = "/v1/apps/{0}/sub_apps/{1}/channels";

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("banned")]
    public bool Banned { get; set; }

    [JsonProperty("banned_msg")]
    public string BannedMsg { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    public static SubAppChannel Create(
      string appId,
      string subAppId,
      Dictionary<string, object> param)
    {
      return Mapper<SubAppChannel>.MapFromJson(Requestor.DoRequest(string.Format("/v1/apps/{0}/sub_apps/{1}/channels", (object) appId, (object) subAppId), "POST", param), (string) null);
    }

    public static SubAppChannel Update(
      string appId,
      string subAppId,
      string channel,
      Dictionary<string, object> param)
    {
      return Mapper<SubAppChannel>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/sub_apps/{1}/channels", (object) appId, (object) subAppId), (object) channel), "PUT", param), (string) null);
    }

    public static SubAppChannel Retrieve(
      string appId,
      string subAppId,
      string channel)
    {
      return Mapper<SubAppChannel>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/sub_apps/{1}/channels", (object) appId, (object) subAppId), (object) channel), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static DeletedSubAppChannel Delete(
      string appId,
      string subAppId,
      string channel)
    {
      return Mapper<DeletedSubAppChannel>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/sub_apps/{1}/channels", (object) appId, (object) subAppId), (object) channel), "DELETE", (Dictionary<string, object>) null), (string) null);
    }
  }
}