using System.Collections.Generic;
using Pingpp.Standard.Net;

namespace Pingpp.Standard.Models
{
    public class RechargeRefund : Pingpp
    {
        private const string BaseUrl = "/v1/apps/{0}/recharges/{1}/refunds";

        public static Refund Create(
            string appId,
            string id,
            Dictionary<string, object> refundParams = null)
        {
            return Mapper<Refund>.MapFromJson(Requestor.DoRequest(string.Format("/v1/apps/{0}/recharges/{1}/refunds", (object) appId, (object) id), "POST", refundParams), (string) null);
        }

        public static Refund Retrieve(string appId, string id, string refunId)
        {
            return Mapper<Refund>.MapFromJson(Requestor.DoRequest(string.Format("{0}/{1}", (object) string.Format("/v1/apps/{0}/recharges/{1}/refunds", (object) appId, (object) id), (object) refunId), "GET", (Dictionary<string, object>) null), (string) null);
        }

        public static RefundList List(
            string appId,
            string id,
            Dictionary<string, object> listParams = null)
        {
            return Mapper<RefundList>.MapFromJson(Requestor.DoRequest(Requestor.FormatUrl(string.Format("/v1/apps/{0}/recharges/{1}/refunds", (object) appId, (object) id), Requestor.CreateQuery(listParams)), "GET", (Dictionary<string, object>) null), (string) null);
        }
    }
}