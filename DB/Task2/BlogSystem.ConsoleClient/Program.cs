using BlogSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var blogService = new BlogService();
            var blog = blogService.GetBlogWithPostsEagerly(2);

            Console.WriteLine("Post of blog 2");
            foreach (var post in blog.Posts)
            {
                Console.WriteLine(post.Content);
            }

            Console.WriteLine();

            var postService = new PostService();
            var posts = postService.GetAllPostOfAllBlogsExplicitly();

            Console.WriteLine("All posts");
            foreach (var post in posts)
            {
                Console.WriteLine(post.Content);
            }
        }
    }
}
