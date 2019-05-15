using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models.Discord
{
    public class AccessTokenResponseModel
    {

        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }

    }
}

    //"access_token": "6qrZcUqja7812RVdnEKjpzOL4CvHBFG",
    //"token_type": "Bearer",
    //"expires_in": 604800,
    //"refresh_token": "D43f5y0ahjqew82jZ4NViEr2YafMKhue",
    //"scope": "identify"
