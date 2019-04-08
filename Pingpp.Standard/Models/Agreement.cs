using System.Collections.Generic;
using Newtonsoft.Json;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
public class Agreement : Pingpp
  {
    private const string BaseUrl = "/v1/agreements";

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("livemode")]
    public bool Livemode { get; set; }

    [JsonProperty("app")]
    public string App { get; set; }

    [JsonProperty("created")]
    public int? Created { get; set; }

    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("contract_no")]
    public string ContractNo { get; set; }

    [JsonProperty("contract_id")]
    public string ContractId { get; set; }

    [JsonProperty("credential")]
    public Dictionary<string, object> Credential { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("time_succeeded")]
    public int? TimeSucceeded { get; set; }

    [JsonProperty("time_canceled")]
    public int? TImeCanceled { get; set; }

    [JsonProperty("failure_code")]
    public string FailureCode { get; set; }

    [JsonProperty("failure_msg")]
    public string FailureMsg { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }

    [JsonProperty("extra")]
    public Dictionary<string, object> Extra { get; set; }

    public static Agreement Create(Dictionary<string, object> param)
    {
      return Mapper<Agreement>.MapFromJson(Requestor.DoRequest("/v1/agreements", "POST", param), (string) null);
    }

    public static Agreement Retrieve(string Id)
    {
      return Mapper<Agreement>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/agreements", (object) Id), "GET", (Dictionary<string, object>) null), (string) null);
    }

    public static Agreement Cancel(string Id)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>()
      {
        {
          "status",
          (object) "canceled"
        }
      };
      return Mapper<Agreement>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) "/v1/agreements", (object) Id), "PUT", dictionary), (string) null);
    }

    public static AgreementList List(Dictionary<string, object> listParams)
    {
      return Mapper<AgreementList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl("/v1/agreements", Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
    }
  }
}