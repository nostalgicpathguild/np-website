using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Models
{
    public class EditPostModel
    {
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        public static EditPostModel GetDetails(int id)
        {
            using (var db = new Database.NPGuildEntities())
            {
                var post = db.Posts.Find(id);

                return new EditPostModel()
                {
                    PostId = id,
                    Content = post.Content,
                    Title = post.Title,
                };
            }

        }

        public int UpdatePost()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var post = db.Posts.Find(PostId);

                post.Content = Content;
                post.Title = Title;
                post.EditedDateTime = DateTime.UtcNow;
                post.Removed = false;

                db.SaveChanges();

                return post.PostId;
            }
        }
    }
}