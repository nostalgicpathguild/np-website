using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace np_website.Resources
{
    public static class AppSettings
    {
        public static string GoogleReCaptchaSiteKey { get { return GetString("GoogleReCaptchaSiteKey"); } }
        public static string GoogleReCaptchaSecretKey { get { return GetString("GoogleReCaptchaSecretKey"); } }
        public static string DiscordClientSecret { get { return GetString("DiscordClientSecret"); } }
        public static string DiscordClientId { get { return GetString("DiscordClientId"); } }

        private static string GetString(string key, string defaultValue = null)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return defaultValue;
            else
                return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
