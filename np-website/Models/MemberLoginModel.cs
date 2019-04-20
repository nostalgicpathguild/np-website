using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class MemberLoginModel : Member
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        /// <summary>
        ///     Validates the user credentials.
        /// </summary>
        /// 
        /// <returns>
        ///     Returns true if the email and passwords match an active account
        ///     in the system.
        /// </returns>
        /// 
        public bool Login()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var member = db.Users.FirstOrDefault(f => f.Email == Email);

                if (member == null)
                    return false;

                var hashed = ComputeHMAC_SHA256(Password, member.PasswordSalt);

                if (member.Password.SequenceEqual(hashed))
                {
                    Resources.MySession.Email = Email;
                    Resources.MySession.CharacterName = member.CharacterName;
                    Resources.MySession.UserLevel = member.UserLevelId;
                    Resources.MySession.UserId = member.UserId;

                    return true;
                }
                else
                    return false;
            }
        }

    }
}
