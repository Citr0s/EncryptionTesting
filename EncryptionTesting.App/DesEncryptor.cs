using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionTesting.App
{
    public static class DesEncryptor
    {
        private static string Encrypt(string strData, string strKey)
        {
            byte[] iv = {10, 20, 30, 40, 50, 60, 70, 80};
            var key = Encoding.UTF8.GetBytes(strKey);   
            var cipher = TripleDES.Create();
            cipher.GenerateKey();

            var inputByteArray = Encoding.UTF8.GetBytes(strData);
            var objmst = new MemoryStream();
            var objcs = new CryptoStream(objmst, cipher.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            objcs.Write(inputByteArray, 0, inputByteArray.Length);
            objcs.FlushFinalBlock();

            return Convert.ToBase64String(objmst.ToArray());
        }

        private static string Decrypt(string strData, string strKey)
        {
            byte[] iv = {10, 20, 30, 40, 50, 60, 70, 80};

            var key = Encoding.UTF8.GetBytes(strKey);   

            var cipher = TripleDES.Create();
            var inputByteArray = Convert.FromBase64String(strData);

            var objmst = new MemoryStream();
            var objcs = new CryptoStream(objmst, cipher.CreateDecryptor(key, iv), CryptoStreamMode.Write);
            objcs.Write(inputByteArray, 0, inputByteArray.Length);
            objcs.FlushFinalBlock();

            var encoding = Encoding.UTF8;
            return encoding.GetString(objmst.ToArray());
        }
    }
}