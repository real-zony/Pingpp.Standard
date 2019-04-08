using System.Collections.Generic;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class OrderRefund : Pingpp
    {
        private const string BaseUrl = "/v1/orders";

        public static RefundList Create(string id, Dictionary<string, object> reParams)
        {
            return Mapper<RefundList>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}/order_refunds", (object) "/v1/orders", (object) id), "POST", reParams), (string) null);
        }

        public static Refund Retrieve(string orId, string reId)
        {
            return Mapper<Refund>.MapFromJson(Requestor.DoRequest(string.Format("/v1/orders/{0}/order_refunds/{1}", (object) orId, (object) reId), "Get", (Dictionary<string, object>) null), (string) null);
        }

        public static RefundList List(string orId, Dictionary<string, object> listParams = null)
        {
            return Mapper<RefundList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/orders/{0}/order_refunds", (object) orId), Requestor.CreateQuery(listParams)), "Get", (Dictionary<string, object>) null), (string) null);
        }
    }
}