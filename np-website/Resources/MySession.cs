using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Resources
{
    public static class MySession
    {

        public static int? UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] != null && int.TryParse(HttpContext.Current.Session["UserId"].ToString(), out int userLevel))
                    return userLevel;
                else
                    return null; // Not Logged In
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static int UserLevel
        {
            get
            {
                if (HttpContext.Current.Session["UserLevel"] != null && int.TryParse(HttpContext.Current.Session["UserLevel"].ToString(), out int userLevel))
                    return userLevel;
                else
                    return 0; // Not Logged In
            }
            set
            {
                HttpContext.Current.Session["UserLevel"] = value;
            }
        }

        public static string CharacterName
        {
            get
            {
                if (HttpContext.Current.Session["CharacterName"] != null)
                    return HttpContext.Current.Session["CharacterName"].ToString();
                else
                    return "Unknown"; // Guest
            }
            set
            {
                HttpContext.Current.Session["CharacterName"] = value;
            }
        }

        public static int aspnetforumUserID
        {
            get
            {
                if (HttpContext.Current.Session["aspnetforumUserID"] != null && int.TryParse(HttpContext.Current.Session["aspnetforumUserID"].ToString(), out int aspnetforumUserID))
                    return aspnetforumUserID;
                else
                    return 0; // Not Logged In
            }
            set
            {
                HttpContext.Current.Session["aspnetforumUserID"] = value;
            }
        }

        public static string aspnetforumUserName
        {
            get
            {
                if (HttpContext.Current.Session["aspnetforumUserName"] != null)
                    return HttpContext.Current.Session["aspnetforumUserName"].ToString();
                else
                    return "Unknown"; // Guest
            }
            set
            {
                HttpContext.Current.Session["aspnetforumUserName"] = value;
            }
        }

        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session["Email"] != null)
                    return HttpContext.Current.Session["Email"].ToString();
                else
                    return "Unknown"; // Guest
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string DiscordAccessToken
        {
            get
            {
                if (HttpContext.Current.Session["DiscordAccessToken"] != null)
                    return HttpContext.Current.Session["DiscordAccessToken"].ToString();
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["DiscordAccessToken"] = value;
            }
        }

        public static string DiscordRefreshToken
        {
            get
            {
                if (HttpContext.Current.Session["DiscordRefreshToken"] != null)
                    return HttpContext.Current.Session["DiscordRefreshToken"].ToString();
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["DiscordRefreshToken"] = value;
            }
        }


    }
}