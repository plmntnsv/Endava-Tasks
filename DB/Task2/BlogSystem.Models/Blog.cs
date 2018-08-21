using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Blog
    {
        public Blog()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Title { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
