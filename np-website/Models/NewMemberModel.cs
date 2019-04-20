using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class NewMemberModel : Member
    {

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Repeat Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
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
                if (db.Users.Any(f => f.Email == Email))
                    throw new Exception("There is already a member with that email!");

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

    }
}