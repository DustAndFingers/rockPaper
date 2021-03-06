using System;
using System.Text;
using System.Security.Cryptography;

namespace rockPaper
{
    class HMAC
    {
        public static string GetHmac(string key, string body)
        {
            byte[] bkey = Encoding.Unicode.GetBytes(key);
            byte[] bbody = Encoding.Unicode.GetBytes(body);
            byte[] hashValue;

            using (HMACSHA256 hmac = new HMACSHA256(bkey))
            {
                hashValue = hmac.ComputeHash(bbody);
            }
            return BitConverter.ToString(hashValue).Replace("-", "");
        }
    }
}
