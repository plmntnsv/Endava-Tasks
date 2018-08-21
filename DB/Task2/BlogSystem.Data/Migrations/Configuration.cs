namespace BlogSystem.Data.Migrations
{
    using BlogSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogSystem.Data.BlogSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogSystem.Data.BlogSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var post1 = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Content = "Content of post 1 for blog 1"
                },
                new Post()
                {
                    Id = 2,
                    Content = "Content of post 2 for blog 1"
                }
            };

            var post2 = new List<Post>()
            {
                new Post()
                {
                    Id = 3,
                    Content = "Content of post 1 for blog 2"
                },
                new Post()
                {
                    Id = 4,
                    Content = "Content of post 2 for blog 2"
                },
                new Post()
                {
                    Id = 5,
                    Content = "Content of post 3 for blog 2"
                }
            };

            var blogs = new List<Blog>()
            {
                new Blog()
                {
                    Id = 1,
                    Title = "Title of blog 1",
                    Posts = post1
                },
                new Blog()
                {
                    Id = 2,
                    Title = "Title of blog 2",
                    Posts = post2
                }
            };

            foreach (var blog in blogs)
            {
                context.Blogs.AddOrUpdate(blog);
            }
        }
    }
}
