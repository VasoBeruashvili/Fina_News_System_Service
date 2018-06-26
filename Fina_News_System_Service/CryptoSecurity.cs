using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.IO;

namespace Fina_News_System_Service
{
    public static class CryptoSecurityInternal
    {
        private  const string passPhrase = "B2C073734F13295722080F9ECA9F44CB";
        private  const string saltValue = "721188621259BEE5C0695104F87D200D";
        private  const string initVector = "@0C574D9t5W6ANN8"; // must be 16 bytes

        internal static bool IsRequestValid(SecureRequest secure, bool CheckWithDate = true)
        {
            if (secure == null)
                return false;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(Decrypt(secure.PrivateKey));
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return ((sb.ToString() == secure.PublicKey) && isValitData(Decrypt(secure.PrivateDateTime), CheckWithDate));
        }

        private static bool isValitData(string datetime, bool CheckWithDate)
        {
            if (!CheckWithDate)
                return true;
            DateTime server_date = DateTime.Now;
            DateTime recieve_date;
            if (!DateTime.TryParseExact(datetime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out recieve_date))
                return false;
            TimeSpan ts = server_date.Subtract(recieve_date);
            if (Math.Abs(ts.Hours) > 3)
                return false;
            return true;
        }

        internal static string Encrypt(string plainText)
        {
            string res = null;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider() { KeySize = 256, Mode = CipherMode.CBC })
            {
                using (MemoryStream _stream = new MemoryStream())
                {
                    using (CryptoStream _cs = new CryptoStream(_stream, aes.CreateEncryptor(new PasswordDeriveBytes(passPhrase, Encoding.ASCII.GetBytes(saltValue), "SHA1", 10000).GetBytes(256 / 8), Encoding.ASCII.GetBytes(initVector)), CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                        _cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        _cs.FlushFinalBlock();
                        _cs.Close();
                    }
                    res = Convert.ToBase64String(_stream.ToArray());
                    _stream.Close();
                }
            }
            return res;
        }

        internal static string Decrypt(string cipherText)
        {

            string res = null;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider() { KeySize = 256, Mode = CipherMode.CBC })
            {
                using (MemoryStream _stream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream _cs = new CryptoStream(_stream, aes.CreateDecryptor(new PasswordDeriveBytes(passPhrase, Encoding.ASCII.GetBytes(saltValue), "SHA1", 10000).GetBytes(256 / 8), Encoding.ASCII.GetBytes(initVector)), CryptoStreamMode.Read))
                    {
                        byte[] plainTextBytes = new byte[Convert.FromBase64String(cipherText).Length];
                        int decryptedByteCount = _cs.Read(plainTextBytes, 0, plainTextBytes.Length);
                        res = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        _cs.Close();
                    }
                    _stream.Close();
                }
            }
            return res;
        }

        internal static SecureString SecureDecrypt(string cipherText)
        {

            SecureString res =new SecureString();
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider() { KeySize = 256, Mode = CipherMode.CBC })
            {
                using (MemoryStream _stream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream _cs = new CryptoStream(_stream, aes.CreateDecryptor(new PasswordDeriveBytes(passPhrase, Encoding.ASCII.GetBytes(saltValue), "SHA1", 10000).GetBytes(256 / 8), Encoding.ASCII.GetBytes(initVector)), CryptoStreamMode.Read))
                    {
                        byte[] plainTextBytes = new byte[Convert.FromBase64String(cipherText).Length];
                        int decryptedByteCount = _cs.Read(plainTextBytes, 0, plainTextBytes.Length);
                        Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).ToList().ForEach(a => res.AppendChar(a));
                        _cs.Close();
                    }
                    _stream.Close();
                }
            }
            return res;
        }

    }
    
}