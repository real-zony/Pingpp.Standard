using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Coupon : Pingpp
  {
    private const string BaseUrl = "/v1/apps";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("actual_amount")]
    public int? ActualAmount { get; set; }

    [JsonProperty("coupon_template")]
    public CouponTemplate CouponTemplate { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("user_times_circulated")]
    public int UserTimesCirculated { get; set; }

    [JsonProperty("order")]
    public string Order { get; set; }

    [JsonProperty("redeemed")]
    public bool Redeemed { get; set; }

    [JsonProperty("time_end")]
    public int? TimeEnd { get; set; }

    [JsonProperty("time_start")]
    public int? TimeStart { get; set; }

    [JsonProperty("user")]
    public string User { get; set; }

    [JsonProperty("valid")]
    public bool Valid { get; set; }

    public static Coupon Create(
      string appId,
      string uid,
      Dictionary<string, object> couParams)
    {
      return Mapper<Coupon>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}/coupons", (object) "/v1/apps", (object) appId, (object) uid), "POST", couParams), (string) null);
    }

    public static CouponList BatchCreate(
      string appId,
      string couTmplId,
      Dictionary<string, object> couParams)
    {
      return Mapper<CouponList>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/coupon_templates/{2}/coupons", (object) "/v1/apps", (object) appId, (object) couTmplId), "POST", couParams), (string) null);
    }

    public static Coupon Retrieve(string appId, string uid, string couId)
    {
      return Mapper<Coupon>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}/coupons/{3}", (object) "/v1/apps", (object) appId, (object) uid, (object) couId), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Coupon Update(
      string appId,
      string uid,
      string couId,
      Dictionary<string, object> couParams)
    {
      return Mapper<Coupon>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}/coupons/{3}", (object) "/v1/apps", (object) appId, (object) uid, (object) couId), "PUT", couParams), (string) null);
    }

    public static Deleted Delete(string appId, string uid, string couId)
    {
      return Mapper<Deleted>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/users/{2}/coupons/{3}", (object) "/v1/apps", (object) appId, (object) uid, (object) couId), "DELETE", (Dictionary<string, object>) null), (string) null);
    }

    public static CouponList List(
      string appId,
      string uid,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<CouponList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/users/{2}/coupons", (object) "/v1/apps", (object) appId, (object) uid), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static CouponList ListInTemplate(
      string appId,
      string couTmplId,
      Dictionary<string, object> listParams = null)
    {
      return Mapper<CouponList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/coupon_templates/{2}/coupons", (object) "/v1/apps", (object) appId, (object) couTmplId), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}