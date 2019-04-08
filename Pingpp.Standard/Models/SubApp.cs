using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class SubApp : Pingpp
  {
    private const string BaseUrl = "/v1/apps/{0}/sub_apps";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("account")]
    public string Account { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("available_methods")]
    public List<string> AvailableMethods { get; set; }

    [JsonProperty("parent_app")]
    public string ParentApp { get; set; }

    [JsonProperty("level")]
    public int Level { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    public static SubAppList List(string appId, Dictionary<string, object> listParams = null)
    {
      return Mapper<SubAppList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/sub_apps", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static SubApp Create(string appId, Dictionary<string, object> param)
    {
      return Mapper<SubApp>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/sub_apps", (object) appId), Requestor.CreateQuery(param)), "POST", (Dictionary<string, object>) null), (string) null);
    }

    public static SubApp Retrieve(string appId, string subAppId)
    {
      return Mapper<SubApp>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/sub_apps", (object) appId), (object) subAppId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static SubApp Update(
      string appId,
      string subAppId,
      Dictionary<string, object> param)
    {
      return Mapper<SubApp>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/sub_apps", (object) appId), (object) subAppId), "PUT", param), (string) null);
    }

    public static Deleted Delete(string appId, string subAppId)
    {
      return Mapper<Deleted>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/sub_apps", (object) appId), (object) subAppId), "DELETE", (Dictionary<string, object>) null), (string) null);
    }
  }
}