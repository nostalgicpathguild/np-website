using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models.GuildBank
{
    public class ReviewDumpModel
    {

        public List<ReviewDumpItemModel> ImportedItems { get; set; }
        public List<ReviewDumpItemModel> MissingItems { get; set; }

    }
}