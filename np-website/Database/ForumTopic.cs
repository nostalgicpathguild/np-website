//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace np_website.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ForumTopic
    {
        public int TopicID { get; set; }
        public int ForumID { get; set; }
        public int UserID { get; set; }
        public string Subject { get; set; }
        public bool Visible { get; set; }
        public int LastMessageID { get; set; }
        public int IsSticky { get; set; }
        public bool IsClosed { get; set; }
        public int ViewsCount { get; set; }
        public int RepliesCount { get; set; }
    }
}
