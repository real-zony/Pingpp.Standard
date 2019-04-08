using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Models;
using Pingpp.Standard.Net;

namespace Pingapp.Standard.Models
{
    public class User : Pingpp.Standard.Pingpp
  {
    private const string BaseUrl = "/v1/apps";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("related_app")]
    public string RelatedApp { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("available_coupons")]
    public int? AvailableCoupons { get; set; }

    [JsonProperty("avatar")]
    public string Avatar { get; set; }

    [JsonProperty("available_balance")]
    public long AvailableBalance { get; set; }

    [JsonProperty("withdrawable_balance")]
    public long WithdrawableBalance { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("identified")]
    public bool Identified { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("mobile")]
    public string Mobile { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("settle_accounts")]
    public List<SettleAccount> SettleAccount { get; set; }

    public static User Create(string appId, Dictionary<string, object> uParams)
    {
      return Mapper<User>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users", (object) "/v1/apps", (object) appId), "POST", uParams), (string) null);
    }

    public static User Retrieve(string appId, string uid)
    {
      return Mapper<User>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}", (object) "/v1/apps", (object) appId, (object) uid), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static User Update(string appId, string uid, Dictionary<string, object> uParams)
    {
      return Mapper<User>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}", (object) "/v1/apps", (object) appId, (object) uid), "PUT", uParams), (string) null);
    }

    public static User Disable(string appId, string uid)
    {
      return Mapper<User>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}", (object) "/v1/apps", (object) appId, (object) uid), "PUT", new Dictionary<string, object>()
      {
        {
          "disabled",
          (object) true
        }
      }), (string) null);
    }

    public static User Enable(string appId, string uid)
    {
      return Mapper<User>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}", (object) "/v1/apps", (object) appId, (object) uid), "PUT", new Dictionary<string, object>()
      {
        {
          "disabled",
          (object) false
        }
      }), (string) null);
    }

    public static UserList List(string appId, Dictionary<string, object> listParams = null)
    {
      return Mapper<UserList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/users", (object) "/v1/apps", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}