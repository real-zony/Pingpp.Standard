using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pingpp.Standard.Exceptions;
using Pingpp.Standard.Models;
using Pingpp.Standard.Net;

namespace Pingapp.Standard.Utils
{
    public class WxPubUtils
  {
    public static string CreateOauthUrlForCode(string appId, string redirectUrl, bool moreInfo)
    {
      return "https://open.weixin.qq.com/connect/oauth2/authorize?" + HttpBuildQuery(new Dictionary<string, string>()
      {
        {
          "appid",
          appId
        },
        {
          "redirect_uri",
          redirectUrl
        },
        {
          "response_type",
          "code"
        },
        {
          "scope",
          moreInfo ? "snsapi_userinfo" : "snsapi_base"
        },
        {
          "state",
          "STATE#wechat_redirect"
        }
      });
    }

    private static string CreateOauthUrlForOpenid(string appId, string appSecret, string code)
    {
      return string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?{0}", (object) HttpBuildQuery(new Dictionary<string, string>()
      {
        {
          "appid",
          appId
        },
        {
          "secret",
          appSecret
        },
        {
          nameof (code),
          code
        },
        {
          "grant_type",
          "authorization_code"
        }
      }));
    }

    public static string GetOpenId(string appId, string appSecret, string code)
    {
      return Mapper<OAuthResult>.MapFromJson(GetRequest(CreateOauthUrlForOpenid(appId, appSecret, code)), (string) null).Openid;
    }

    public static string GetWxLiteOpenId(string appId, string appSecret, string code)
    {
      return Mapper<WxLiteOauthResult>.MapFromJson(GetRequest(CreateOauthUrlForWxLiteOpenid(appId, appSecret, code)), (string) null).Openid;
    }

    private static string CreateOauthUrlForWxLiteOpenid(
      string appId,
      string appSecret,
      string code)
    {
      return string.Format("https://api.weixin.qq.com/sns/jscode2session?{0}", (object) HttpBuildQuery(new Dictionary<string, string>()
      {
        {
          "appid",
          appId
        },
        {
          "secret",
          appSecret
        },
        {
          "js_code",
          code
        },
        {
          "grant_type",
          "authorization_code"
        }
      }));
    }

    private static string HttpBuildQuery(Dictionary<string, string> queryString)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<string, string> keyValuePair in queryString)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append('&');
        stringBuilder.Append(Requestor.UrlEncodePair(keyValuePair.Key, keyValuePair.Value));
      }
      return stringBuilder.ToString();
    }

    private static string ReadStream(Stream stream)
    {
      using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
        return streamReader.ReadToEnd();
    }

    internal static string GetRequest(string url)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.Method = "GET";
      try
      {
        using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
          return response == null ? (string) null : ReadStream(response.GetResponseStream());
      }
      catch (WebException ex)
      {
        throw new WebException(ex.Message);
      }
    }

    public static string GetJsApiTicket(string appId, string appSecret)
    {
      Dictionary<string, string> queryString = new Dictionary<string, string>();
      queryString.Add("appid", appId);
      queryString.Add("secret", appSecret);
      queryString.Add("grant_type", "client_credential");
      JObject jobject = JObject.Parse(GetRequest("https://api.weixin.qq.com/cgi-bin/token?" + HttpBuildQuery(queryString)));
      queryString.Clear();
      queryString.Add("access_token", ((object) jobject.GetValue("access_token")).ToString());
      queryString.Add("type", "jsapi");
      return ((object) JObject.Parse(GetRequest("https://api.weixin.qq.com/cgi-bin/ticket/getticket?" + HttpBuildQuery(queryString))).GetValue("ticket")).ToString();
    }

    public static string GetSignature(string charge, string jsapiTicket, string url)
    {
      if (charge == null || jsapiTicket == null || (string.IsNullOrEmpty(charge) || string.IsNullOrEmpty(jsapiTicket)))
        return null;
      Charge charge1 = JsonConvert.DeserializeObject<Charge>(charge);
      string str = JsonConvert.SerializeObject(charge1.Credential);
      if (string.IsNullOrEmpty(str) || !charge1.ToString().Contains("credential"))
        return null;
      if (!str.Contains("wx_pub"))
        return null;
      JObject jobject = JObject.Parse(str);
      if (!str.Contains("wx_pub"))
        throw new PingppException("credential doesn't contain key wx_pub");
      JToken jtoken = jobject.SelectToken("wx_pub");
      jtoken.SelectToken("timeStamp");
      string s = "jsapi_ticket=" + jsapiTicket + "&noncestr=" + jtoken.SelectToken("nonceStr") + "&timestamp=" + (object) jtoken.SelectToken("timeStamp") + "&url=" + url;
      SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
      byte[] hash = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
      cryptoServiceProvider.Clear();
      cryptoServiceProvider.Dispose();
      return Convert.ToBase64String(hash);
    }
  }
}