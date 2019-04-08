using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Pingpp.Standard.Utils
{
  public class RsaUtils
  {
    public static string RsaSign(string data, byte[] privateKey)
    {
      if (privateKey == null)
        return "";
      byte[] bytes = Encoding.UTF8.GetBytes(data);
      return Convert.ToBase64String(DecodeRsaPrivateKey(privateKey).SignData(bytes, (object) "SHA256"));
    }

    private static RSACryptoServiceProvider DecodeRsaPrivateKey(
      byte[] privkey)
    {
      BinaryReader binr = new BinaryReader(new MemoryStream(privkey));
      try
      {
        switch (binr.ReadUInt16())
        {
          case 33072:
            binr.ReadByte();
            break;
          case 33328:
            binr.ReadInt16();
            break;
          default:
            return null;
        }

        if (binr.ReadUInt16() != 258 || binr.ReadByte() != 0)
          return null;
        int integerSize1 = GetIntegerSize(binr);
        byte[] numArray1 = binr.ReadBytes(integerSize1);
        int integerSize2 = GetIntegerSize(binr);
        byte[] numArray2 = binr.ReadBytes(integerSize2);
        int integerSize3 = GetIntegerSize(binr);
        byte[] numArray3 = binr.ReadBytes(integerSize3);
        int integerSize4 = GetIntegerSize(binr);
        byte[] numArray4 = binr.ReadBytes(integerSize4);
        int integerSize5 = GetIntegerSize(binr);
        byte[] numArray5 = binr.ReadBytes(integerSize5);
        int integerSize6 = GetIntegerSize(binr);
        byte[] numArray6 = binr.ReadBytes(integerSize6);
        int integerSize7 = GetIntegerSize(binr);
        byte[] numArray7 = binr.ReadBytes(integerSize7);
        int integerSize8 = GetIntegerSize(binr);
        byte[] numArray8 = binr.ReadBytes(integerSize8);
        RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
        cryptoServiceProvider.ImportParameters(new RSAParameters()
        {
          Modulus = numArray1,
          Exponent = numArray2,
          D = numArray3,
          P = numArray4,
          Q = numArray5,
          DP = numArray6,
          DQ = numArray7,
          InverseQ = numArray8
        });
        return cryptoServiceProvider;
      }
      finally
      {
        binr.Close();
      }
    }

    private static int GetIntegerSize(BinaryReader binr)
    {
      if (binr.ReadByte() != 2)
        return 0;
      byte num1 = binr.ReadByte();
      int num2;
      switch (num1)
      {
        case 129:
          num2 = binr.ReadByte();
          break;
        case 130:
          byte num3 = binr.ReadByte();
          num2 = BitConverter.ToInt32(new byte[]
          {
            binr.ReadByte(),
            num3,
            0,
            0
          }, 0);
          break;
        default:
          num2 = num1;
          break;
      }

      while (binr.ReadByte() == 0)
        --num2;
      binr.BaseStream.Seek(-1L, SeekOrigin.Current);
      return num2;
    }
  }
}