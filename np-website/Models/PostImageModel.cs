using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class PostImageModel
    {
        public string location { get; set; }

        public static string GenerateThumbprint()
        {
            var validChars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var length = 16;
            var r = new Random();
            var output = string.Empty;

            for(var i = 0; i < length; i++)
            {
                output += validChars[r.Next(length)];
            }

            return output;
        }

    }
}