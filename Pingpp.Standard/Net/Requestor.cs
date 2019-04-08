using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Pingpp.Standard.Exceptions;
using Pingpp.Standard.Models;
using Pingpp.Standard.Utils;

namespace Pingpp.Standard.Net
{
  internal class Requestor : Pingpp
  {
    internal static HttpWebRequest GetRequest(
      string path,
      string method,
      string timestamp,
      string sign)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(ApiBase + path);
      httpWebRequest.Headers.Add("Authorization", $"Bearer {(object) ApiKey}");
      if (!string.IsNullOrEmpty(ApiVersion))
        httpWebRequest.Headers.Add("Pingplusplus-Version", ApiVersion);
      httpWebRequest.Headers.Add("Pingplusplus-Request-Timestamp", timestamp);
      httpWebRequest.Headers.Add("Accept-Language", AcceptLanguage);
      if (!string.IsNullOrEmpty(sign))
        httpWebRequest.Headers.Add("Pingplusplus-Signature", sign);
      Dictionary<string, object> dictionary = new Dictionary<string, object>()
      {
        {
          "lang",
          "csharp"
        },
        {
          "publisher",
          "pingpp"
        },
        {
          "lang.version",
          Environment.Version.ToString()
        },
        {
          "os.version",
          Environment.OSVersion.ToString()
        },
        {
          "bindings.version",
          Version
        }
      };
      httpWebRequest.Headers.Add("Pingpp-Client-User-Agent", JsonConvert.SerializeObject((object) dictionary));
      httpWebRequest.UserAgent = "Pingpp/v1 CsharpBindings/" + Version;
      httpWebRequest.ContentType = "application/json;charset=utf-8";
      httpWebRequest.Timeout = DefaultTimeout;
      httpWebRequest.ReadWriteTimeout = DefaultReadAndWriteTimeout;
      httpWebRequest.Method = method;
      return httpWebRequest;
    }

    internal static string DoRequest(string path, string method, Dictionary<string, object> param = null)
    {
      if (string.IsNullOrEmpty(ApiKey))
        throw new PingppException("No API key provided.  (HINT: set your API key using \"Pingpp::setApiKey(<API-KEY>)\".  You can generate API keys from the Pingpp web interface.  See https://pingxx.com/document/api for details.");
      try
      {
        method = method.ToUpper();
        string str = "";
        string sign = "";
        string timestamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000L) / 10000000L).ToString();
        if ((method.Equals("POST") || method.Equals("PUT")) && param != null)
          str = JsonConvert.SerializeObject((object) param, (Formatting) 1);
        try
        {
          if (PrivateKey != null)
            sign = RsaUtils.RsaSign(str + path + timestamp, PrivateKey);
        }
        catch (Exception ex)
        {
          throw new PingppException("Sign request error." + ex.Message);
        }

        HttpWebRequest request = GetRequest(path, method, timestamp, sign);
        if (method.Equals("POST") || method.Equals("PUT"))
        {
          using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
          {
            streamWriter.Write(str);
            streamWriter.Flush();
            streamWriter.Close();
          }
        }

        HttpWebResponse response;
        using (response = request.GetResponse() as HttpWebResponse)
          return response == null ? (string) null : ReadStream(response.GetResponseStream());
      }
      catch (WebException ex)
      {
        if (ex.Response == null)
          throw new WebException(ex.Message);
        HttpStatusCode statusCode = ((HttpWebResponse) ex.Response).StatusCode;
        if (statusCode == HttpStatusCode.BadGateway && BadGateWayMatch && MaxRetry < MaxNetworkRetries)
        {
          ++MaxRetry;
          DoRequest(path, method, param);
        }

        Error pingppError = Mapper<Error>.MapFromJson(ReadStream(ex.Response.GetResponseStream()), "error");
        throw new PingppException(pingppError, statusCode, pingppError.ErrorType, pingppError.Message);
      }
    }

    private static string ReadStream(Stream stream)
    {
      using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
        return streamReader.ReadToEnd();
    }

    internal static Dictionary<string, string> FormatParams(
      Dictionary<string, object> param)
    {
      if (param == null)
        return new Dictionary<string, string>();
      Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
      foreach (KeyValuePair<string, object> keyValuePair1 in param)
      {
        Dictionary<string, string> dictionary2 = keyValuePair1.Value as Dictionary<string, string>;
        if (dictionary2 != null)
        {
          Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
          foreach (KeyValuePair<string, string> keyValuePair2 in dictionary2)
            dictionary3.Add($"{(object) keyValuePair1.Key}[{(object) keyValuePair2.Key}]", (object) keyValuePair2.Value);
          foreach (KeyValuePair<string, string> formatParam in FormatParams(dictionary3))
            dictionary1.Add(formatParam.Key, formatParam.Value);
        }
        else if (keyValuePair1.Value is Dictionary<string, object>)
        {
          Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
          foreach (KeyValuePair<string, object> keyValuePair2 in (Dictionary<string, object>) keyValuePair1.Value)
            dictionary3.Add(string.Format("{0}[{1}]", (object) keyValuePair1.Key, (object) keyValuePair2.Key), (object) keyValuePair2.Value.ToString());
          foreach (KeyValuePair<string, string> formatParam in FormatParams(dictionary3))
            dictionary1.Add(formatParam.Key, formatParam.Value);
        }
        else if (keyValuePair1.Value is IList)
        {
          List<object> source = (List<object>) keyValuePair1.Value;
          Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
          int num = source.Count<object>();
          for (int index = 0; index < num; ++index)
            dictionary3.Add(string.Format("{0}[{1}]", (object) keyValuePair1.Key, (object) index), source[index]);
          foreach (KeyValuePair<string, string> formatParam in FormatParams(dictionary3))
            dictionary1.Add(formatParam.Key, formatParam.Value);
        }
        else
        {
          if ("".Equals(keyValuePair1.Value))
            throw new PingppException(string.Format("You cannot set '{0}' to an empty string. We interpret empty strings as null in requests. You may set '{0}' to null to delete the property.", (object) keyValuePair1.Key));
          if (keyValuePair1.Value == null)
            dictionary1.Add(keyValuePair1.Key, "");
          else
            dictionary1.Add(keyValuePair1.Key, keyValuePair1.Value.ToString());
        }
      }

      return dictionary1;
    }

    internal static string CreateQuery(Dictionary<string, object> param)
    {
      Dictionary<string, string> dictionary = FormatParams(param);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<string, string> keyValuePair in dictionary)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append("&");
        stringBuilder.Append(UrlEncodePair(keyValuePair.Key, keyValuePair.Value));
      }

      return stringBuilder.ToString();
    }

    internal static string UrlEncodePair(string k, string v)
    {
      return $"{(object) UrlEncode(k)}={(object) UrlEncode(v)}";
    }

    private static string UrlEncode(string str)
    {
      if (!string.IsNullOrEmpty(str))
        return HttpUtility.UrlEncode(str, Encoding.UTF8);
      return (string) null;
    }

    internal static string FormatUrl(string url, string query)
    {
      if (!string.IsNullOrEmpty(query))
        return $"{(object) url}{(url.Contains("?") ? (object) "&" : (object) "?")}{(object) query}";
      return url;
    }
  }
}