using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace np_website.Models
{
    public class NewPostModel
    {

        [Required]
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        public int CreatePost()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var post = new Database.Post()
                {
                    TimeStamp = DateTime.UtcNow,
                    Content = Content,
                    AuthorId = Resources.MySession.UserId.Value,
                    Title = Title,
                    Removed = false
                };

                db.Posts.Add(post);
                db.SaveChanges();

                return post.PostId;
            }
        }

    }
}