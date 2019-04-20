using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace np_website.Models
{
    public class NewMemberModel
    {
        private const int SaltSize = 32;

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Repeat Password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match!")]
        public string PasswordRepeat { get; set; }

        [Display(Name = "Character Name")]
        [Required]
        public string CharacterName { get; set; }


        /// <summary>
        ///     Creates a new member from the current state of the model.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns the database id of the member.
        /// </returns>
        /// 
        public int CreateMember()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var member = new Database.User()
                {
                    Email = Email,
                    CharacterName = CharacterName,
                    UserLevelId = 1 // Guest
                };

                member.PasswordSalt = GenerateSalt();
                member.Password = ComputeHMAC_SHA256(Password, member.PasswordSalt);

                db.Users.Add(member);
                db.SaveChanges();

                return member.UserId;
            }
        }






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