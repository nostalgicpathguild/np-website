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

        public static (int, List<PostModel>) GetPosts(int pageIndex, int recsPerPage)
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

                var maxPages = (int)Math.Ceiling((decimal)posts.Count() / recsPerPage);
                pageIndex = pageIndex > maxPages ? maxPages : pageIndex;
                pageIndex = pageIndex < 0 ? 0 : pageIndex;

                return (maxPages, posts.OrderByDescending(f => f.PostDate).Skip(pageIndex * recsPerPage).Take(recsPerPage).ToList());
            }
        }

    }
}