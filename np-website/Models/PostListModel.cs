using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace np_website.Models
{
    public class PostListModel
    {
        public List<PostItemModel> Posts { get; set; }

        public static List<PostItemModel> GetPosts()
        {
            using (var db = new Database.NPGuildEntities())
            {
                var posts = from p in db.Posts
                            where p.Removed == false
                            select new PostItemModel
                            {
                                PostId = p.PostId,
                                Title = p.Title,
                                Author = p.User.CharacterName,
                                PostDate = p.TimeStamp
                            };

                return posts.OrderByDescending(f => f.PostDate).ToList();
            }
        }

        public class PostItemModel
        {

            public int PostId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime PostDate { get; set; }

        }

    }
}
