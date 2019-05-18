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

                    var forumUser = db.ForumUsers.FirstOrDefault(f => f.UserName == member.CharacterName && f.Email == member.Email);

                    Resources.MySession.aspnetforumUserID = forumUser.UserID;
                    Resources.MySession.aspnetforumUserName = member.CharacterName;

                    var authenticatedSession = new Database.AuthenticatedSession()
                    {
                        ASPNetSessionId = HttpContext.Current.Session.SessionID,
                        UserId = member.UserId,
                        IpAddress = HttpContext.Current.Request.UserHostAddress
                    };

                    db.AuthenticatedSessions.Add(authenticatedSession);
                    db.SaveChanges();

                    var authCookie = new HttpCookie("npGuildIdentity");
                    authCookie.Value = HttpContext.Current.Session.SessionID;
                    authCookie.Expires = DateTime.MaxValue;
                    HttpContext.Current.Response.SetCookie(authCookie);

                    return true;
                }
                else
                    return false;
            }
        }

    }
}
