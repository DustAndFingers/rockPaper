using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace rockPaper
{
    class Key
    {
        public static string GetHmacKey()
        {
            var generator = RandomNumberGenerator.Create();
            var key = new byte[16];
            generator.GetNonZeroBytes(key);
            return BitConverter.ToString(key).Replace("-", "");
        }
    }
}
