using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class HomeViewModel
    {
        public List<PostModel> Posts { get; set; }
        public List<EventItemModel> Events { get; set; }

        public int PostsPageIndex { get; set; } = 0;
        public int PostsRecsPerPage { get; set; } = 5;
        public int PostPageCount { get; set; }

    }
}