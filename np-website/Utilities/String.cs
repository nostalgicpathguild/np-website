using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace np_website.Utilities
{
    public static class String
    {
        public static string Base64Encode(string value)
        {
            var credBytes = Encoding.ASCII.GetBytes(value);
            return Convert.ToBase64String(credBytes);
        }

        public static byte[] GetHash(string value)
        {
            var algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
        }

        public static string GetHashString(string value)
        {
            var sb = new StringBuilder();
            var bytes = GetHash(value);
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}