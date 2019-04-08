using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Order : Pingpp
  {
    [JsonProperty("paid")]
    public bool Paid;
    private const string BaseUrl = "/v1/orders";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("refunded")]
    public bool Refunded { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("uid")]
    public string Uid { get; set; }

    [JsonProperty("merchant_order_no")]
    public string MerchantOrderNo { get; set; }

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("coupon_amount")]
    public int? CouponAmount { get; set; }

    [JsonProperty("amount_refunded")]
    public int? AmountRefunded { get; set; }

    [JsonProperty("actual_amount")]
    public int ActualAmount { set; get; }

    [JsonProperty("amount_paid")]
    public int AmountPaid { set; get; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("subject")]
    public string Subject { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("client_ip")]
    public string ClientIp { get; set; }

    [JsonProperty("time_paid")]
    public int? TimePaid { get; set; }

    [JsonProperty("time_expire")]
    public int? TimeExpire { get; set; }

    [JsonProperty("charge")]
    public string Charge { get; set; }

    [JsonProperty("coupon")]
    public string Coupon { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("charge_essentials")]
    public Dictionary<string, object> ChargeEssentials { get; set; }

    [JsonProperty("available_balance")]
    public long AvailableBalance { set; get; }

    [JsonProperty("receipt_app")]
    public string ReceiptApp { get; set; }

    [JsonProperty("service_app")]
    public string ServiceApp { get; set; }

    [JsonProperty("available_methods")]
    public List<string> AvailableMethods { get; set; }

    [JsonProperty("charges")]
    public ChargeList Charges { set; get; }

    public static Order Create(Dictionary<string, object> orParams)
    {
      return Mapper<Order>.MapFromJson(Requestor.DoRequest("/v1/orders", "POST", orParams), (string) null);
    }

    public static Order Retrieve(string id)
    {
      return Mapper<Order>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/orders", (object) id), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Order Pay(string id, Dictionary<string, object> payParams = null)
    {
      return Mapper<Order>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/pay", (object) "/v1/orders", (object) id), "POST", payParams), (string) null);
    }

    public static Order Cancel(string id, Dictionary<string, object> cancelParams = null)
    {
      string path = string.Format("{0}/{1}", (object) "/v1/orders", (object) id);
      if (cancelParams == null)
        cancelParams = new Dictionary<string, object>()
        {
          {
            "status",
            (object) "canceled"
          }
        };
      if (!cancelParams.ContainsKey("status"))
        cancelParams.Add("status", (object) "canceled");
      Dictionary<string, object> dictionary = cancelParams;
      return Mapper<Order>.MapFromJson(Requestor.DoRequest(path, "PUT", dictionary), (string) null);
    }

    public static OrderList List(Dictionary<string, object> listParams = null)
    {
      return Mapper<OrderList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/orders", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static ChargeList ChargeList(string id, Dictionary<string, object> listParams = null)
    {
      return Mapper<ChargeList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("{0}/{1}/charges", (object) "/v1/orders", (object) id), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Charge ChargeRetrieve(string id, string chargeId)
    {
      return Mapper<Charge>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/charges/{2}", (object) "/v1/orders", (object) id, (object) chargeId), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}