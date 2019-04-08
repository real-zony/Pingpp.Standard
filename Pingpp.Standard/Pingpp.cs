using System;
using System.IO;
using Newtonsoft.Json;
using Pingpp.Standard.Exceptions;

namespace Pingpp.Standard
{
  public abstract class Pingpp
  {
    public static volatile string AcceptLanguage = "zh-CN";
    public static volatile string ApiBase = "https://api.pingxx.com";
    public static volatile string Version = "1.5.0";
    public static volatile bool BadGateWayMatch = true;
    public static volatile int MaxNetworkRetries = 1;
    protected static volatile int MaxRetry = 0;
    public static int DefaultTimeout = 80000;
    public static int DefaultReadAndWriteTimeout = 20000;
    public static volatile string ApiVersion;
    public static volatile string ApiKey;
    public static volatile byte[] PrivateKey;

    public static void SetMaxNetworkRetries(int maxNetworkRetries)
    {
      MaxNetworkRetries = maxNetworkRetries;
    }

    public static void SetBadGateWayMatch(bool badGateWayMatch)
    {
      BadGateWayMatch = badGateWayMatch;
    }

    public static void SetApiBase(string newApiBase)
    {
      ApiBase = newApiBase;
    }

    internal static string GetApiKey()
    {
      return ApiKey;
    }

    public static void SetApiKey(string newApiKey)
    {
      ApiKey = newApiKey;
    }

    internal static byte[] GetPrivateKey()
    {
      return PrivateKey;
    }

    public static void SetPrivateKey(string newPrivateKey)
    {
      PrivateKey = FormatPrivateKey(newPrivateKey);
    }

    public static void SetPrivateKeyPath(string newPrivateKeyPath)
    {
      try
      {
        FileStream fileStream = new FileStream(newPrivateKeyPath, FileMode.Open);
        PrivateKey = FormatPrivateKey(new StreamReader((Stream) fileStream).ReadToEnd());
        fileStream.Close();
      }
      catch (IOException ex)
      {
        throw new PingppException("Private key read error. " + (object) ex);
      }
    }

    public override string ToString()
    {
      return JsonConvert.SerializeObject((object) this);
    }

    private static byte[] FormatPrivateKey(string privateKeyContent)
    {
      privateKeyContent = privateKeyContent.Replace("\r", "").Replace("\n", "");
      if (privateKeyContent.StartsWith("-----BEGIN RSA PRIVATE KEY-----"))
        privateKeyContent = privateKeyContent.Substring(31);
      if (privateKeyContent.EndsWith("-----END RSA PRIVATE KEY-----"))
        privateKeyContent = privateKeyContent.Substring(0, privateKeyContent.Length - 29);
      byte[] numArray = Convert.FromBase64String(privateKeyContent);
      if (numArray.Length >= 162)
        return numArray;
      throw new PingppException("Private key content is incorrect.");
    }
  }
}