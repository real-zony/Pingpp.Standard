using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class SettleAccount : Pingpp
  {
    public const string BaseUrl = "/v1/apps/{0}/users/{1}/settle_accounts";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("recipient")]
    public Dictionary<string, object> recipient { get; set; }

    public static SettleAccount Create(
      string appId,
      string userId,
      Dictionary<string, object> param)
    {
      return Mapper<SettleAccount>.MapFromJson(Requestor.DoRequest(string.Format("/v1/apps/{0}/users/{1}/settle_accounts", (object) appId, (object) userId), "POST", param), (string) null);
    }

    public static SettleAccount Retrieve(
      string appId,
      string userId,
      string settleAccountId)
    {
      return Mapper<SettleAccount>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/users/{1}/settle_accounts", (object) appId, (object) userId), (object) settleAccountId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Deleted Delete(string appId, string userId, string settleAccountId)
    {
      return Mapper<Deleted>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/users/{1}/settle_accounts", (object) appId, (object) userId), (object) settleAccountId), "DELETE", (Dictionary<string, object>) null), (string) null);
    }

    public static SettleAccountList List(
      string appId,
      string userId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<SettleAccountList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/users/{1}/settle_accounts", (object) appId, (object) userId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}