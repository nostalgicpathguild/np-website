using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime? EditedDate { get; set; }

        public static List<PostModel> GetPosts()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var posts = from p in db.Posts
                            where p.Removed == false
                            select new PostModel
                            {
                                Title = p.Title,
                                Content = p.Content,
                                Author = p.User.CharacterName,
                                PostDate = p.TimeStamp,
                                EditedDate = p.EditedDateTime
                            };

                return posts.OrderByDescending(f => f.PostDate).ToList();
            }
        }

    }
}