using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class CouponTemplate : Pingpp
  {
    private const string BaseUrl = "/v1/apps";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("amount_available")]
    public int? AmountAvailable { get; set; }

    [JsonProperty("amount_off")]
    public int? AmountOff { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("expiration")]
    public object Expiration { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("max_circulation")]
    public int? MaxCirculation { get; set; }

    [JsonProperty("max_user_circulation")]
    public int MaxUserCirculation { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("percent_off")]
    public int? PercentOff { get; set; }

    [JsonProperty("refundable")]
    public bool Refundable { get; set; }

    [JsonProperty("times_circulated")]
    public int? TimesCirculated { get; set; }

    [JsonProperty("times_redeemed")]
    public int? TimesRedeemed { get; set; }

    [JsonProperty("type")]
    public int? Type { get; set; }

    public static CouponTemplate Create(
      string appId,
      Dictionary<string, object> couTmplParams)
    {
      return Mapper<CouponTemplate>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/coupon_templates", (object) "/v1/apps", (object) appId), "POST", couTmplParams), (string) null);
    }

    public static CouponTemplate Retrieve(string appId, string couTmplId)
    {
      return Mapper<CouponTemplate>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/coupon_templates/{2}", (object) "/v1/apps", (object) appId, (object) couTmplId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static CouponTemplate Update(
      string appId,
      string couTmplId,
      Dictionary<string, object> couTmplParams)
    {
      return Mapper<CouponTemplate>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/coupon_templates/{2}", (object) "/v1/apps", (object) appId, (object) couTmplId), "PUT", couTmplParams), (string) null);
    }

    public static Deleted Delete(string appId, string couTmplId)
    {
      return Mapper<Deleted>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/coupon_templates/{2}", (object) "/v1/apps", (object) appId, (object) couTmplId), "DELETE", (Dictionary<string, object>) null), (string) null);
    }

    public static CouponTemplateList List(
      string appId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<CouponTemplateList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/coupon_templates", (object) "/v1/apps", (object) appId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}