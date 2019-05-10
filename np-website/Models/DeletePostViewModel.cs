using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class DeletePostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public static DeletePostViewModel GetDetails(int id)
        {
            using (var db = new Database.NPGuildEntities())
            {
                var post = db.Posts.Find(id);

                return new DeletePostViewModel()
                {
                    PostId = post.PostId,
                    Title = post.Title
                };
            }
        }

        public void Delete()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var post = db.Posts.Find(PostId);
                post.Removed = true;
                db.SaveChanges();
            }
        }
    }
}