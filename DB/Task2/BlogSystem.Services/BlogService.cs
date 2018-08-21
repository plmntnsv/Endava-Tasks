using BlogSystem.Data;
using BlogSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Services
{
    public class BlogService
    {
        public BlogModel GetBlogWithPostsEagerly(int blogId)
        {
            using (var context = new BlogSystemContext())
            {
                var blog = context.Blogs
                   .Include("Posts")
                   .Where(b => b.Id == blogId)
                   .FirstOrDefault();

                return new BlogModel()
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Posts = blog.Posts.Select(p => new PostModel() { Id = p.Id, Content = p.Content, NumberOfLikes = p.NumberOfLikes}).ToList()
                };
            }
        }

        
    }
}
