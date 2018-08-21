using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class BlogSystemContext : DbContext
    {
        public BlogSystemContext()
            :base("name=BlogSystemDbContext")
        {
            Database.SetInitializer<BlogSystemContext>(new CreateDatabaseIfNotExists<BlogSystemContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
