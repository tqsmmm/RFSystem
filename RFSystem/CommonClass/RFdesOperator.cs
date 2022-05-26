using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RFSystem
{
    public class RFdesOperator
    {
        private string decryptKey = null;
        private string encryptKey = null;
        private string inputString = null;
        private string noteMessage = null;
        private string outString = null;

        public void DesDecrypt()
        {
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };

            byte[] buffer = new byte[inputString.Length];

            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                buffer = Convert.FromBase64String(inputString);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                outString = new UTF8Encoding().GetString(stream.ToArray());
            }
            catch (Exception exception)
            {
                noteMessage = exception.Message;
            }
        }

        public void DesEncrypt()
        {
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };

            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                outString = Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception exception)
            {
                noteMessage = exception.Message;
            }
        }

        public static string getMd5Hash(string input)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public void MD5Encrypt()
        {
            byte[] bytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(inputString));
            outString = Encoding.UTF8.GetString(bytes);
        }

        public string DecryptKey
        {
            get
            {
                return decryptKey;
            }
            set
            {
                decryptKey = value;
            }
        }

        public string EncryptKey
        {
            get
            {
                return encryptKey;
            }
            set
            {
                encryptKey = value;
            }
        }

        public string InputString
        {
            get
            {
                return inputString;
            }
            set
            {
                inputString = value;
            }
        }

        public string NoteMessage
        {
            get
            {
                return noteMessage;
            }
            set
            {
                noteMessage = value;
            }
        }

        public string OutString
        {
            get
            {
                return outString;
            }
            set
            {
                outString = value;
            }
        }
    }
}
