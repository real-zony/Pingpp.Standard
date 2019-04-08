using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class RoyaltyTemplate : Pingpp
  {
    private const string BaseUrl = "/v1/royalty_templates";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("rule")]
    public Dictionary<string, object> Rule { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    public static RoyaltyTemplate Create(Dictionary<string, object> createParams)
    {
      return Mapper<RoyaltyTemplate>.MapFromJson(Requestor.DoRequest("/v1/royalty_templates", "POST", createParams), (string) null);
    }

    public static RoyaltyTemplate Retrieve(string royaltyTemplateId)
    {
      return Mapper<RoyaltyTemplate>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalty_templates", (object) royaltyTemplateId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static RoyaltyTemplate Update(
      string royaltyTemplateId,
      Dictionary<string, object> updateParams)
    {
      return Mapper<RoyaltyTemplate>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalty_templates", (object) royaltyTemplateId), "PUT", updateParams), (string) null);
    }

    public static Deleted Delete(string royaltyTemplateId)
    {
      return Mapper<Deleted>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/royalty_templates", (object) royaltyTemplateId), "DELETE", (Dictionary<string, object>) null), (string) null);
    }

    public static RoyaltyTemplateList List(Dictionary<string, object> listParams = null)
    {
      return Mapper<RoyaltyTemplateList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/royalty_templates", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}