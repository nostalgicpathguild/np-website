using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models.GuildBank
{
    public class BrowseModel
    {
        public List<BrowseItemModel> Items { get; set; } = new List<BrowseItemModel>();
        public string Search { get; set; }

    }
}