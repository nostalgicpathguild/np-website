using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models.GuildBank
{
    public class ReviewDumpItemModel
    {

        public string CharacterName { get; set; }
        public string Name { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public int Slots { get; set; }
        public int PreviousCount { get; set; }

    }
}