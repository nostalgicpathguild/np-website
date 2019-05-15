using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models.Discord
{
    public class AccessTokenRequestModel
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; } = "authorization_code";
        public string code { get; set; }
        public string redirect_uri { get; set; }
        public string scope { get; set; } = "identify email";
    }
}

    //'client_id': CLIENT_ID,
    //'client_secret': CLIENT_SECRET,
    //'grant_type': 'authorization_code',
    //'code': code,
    //'redirect_uri': REDIRECT_URI,
    //'scope': 'identify email connections'
