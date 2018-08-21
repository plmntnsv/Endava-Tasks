using BlogSystem.Data;
using BlogSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services
{
    public class PostService
    {
        public IEnumerable<PostModel> GetAllPostOfAllBlogsExplicitly()
        {
            using (var context = new BlogSystemContext())
            {
                var result = new List<PostModel>();
                var blogs = context.Blogs.ToList();

                foreach (var blog in blogs)
                {
                    context.Entry(blog).Collection(b => b.Posts).Load();

                    foreach (var post in blog.Posts)
                    {
                        result.Add(new PostModel()
                        {
                            Id = post.Id,
                            Content = post.Content,
                            NumberOfLikes = post.NumberOfLikes
                        });
                    }
                }
                
                return result;
            }
        }
    }
}
