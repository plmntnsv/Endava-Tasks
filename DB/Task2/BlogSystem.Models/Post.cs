using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models
{
    public class Post
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 1)]
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
        public virtual Blog Blog { get; set; }
    }
}