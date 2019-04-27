using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace np_website.Models
{
    public class GoogleReCaptchaValidator
    {
        private string recaptchaResponse;

        public GoogleReCaptchaValidator(HttpRequestBase request)
        {
            recaptchaResponse = request["g-recaptcha-response"];
        }

        public GoogleReCaptchaValidator(string response)
        {
            recaptchaResponse = response;
        }

        public bool ValidateRequest()
        {

            if (string.IsNullOrEmpty(Resources.AppSettings.GoogleReCaptchaSecretKey))
                return true;
            else
            {
                var client = new WebClient();
                var reply = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={Resources.AppSettings.GoogleReCaptchaSecretKey}&response={recaptchaResponse}");
                var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

                return captchaResponse.Success;
            }

        }

        internal class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }
    }
}