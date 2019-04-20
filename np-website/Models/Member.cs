using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace np_website.Models
{
    public abstract class Member
    {
        private const int SaltSize = 32;

        /// <summary>
        ///     Generates a random hash salt.
        /// </summary>
        /// 
        internal static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[SaltSize];

                rng.GetBytes(randomNumber);

                return randomNumber;

            }
        }

        /// <summary>
        ///     Hashes the input based on the given salt.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns the hashed value.
        /// </returns>
        /// 
        /// <param name="value">The value to hash</param>
        /// <param name="salt">The salt used in the hashing algorithm.</param>
        /// 
        internal static byte[] ComputeHMAC_SHA256(string value, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
        }
    }
}