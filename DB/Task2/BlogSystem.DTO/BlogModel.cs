using System.Collections.Generic;

namespace BlogSystem.DTO
{
    public class BlogModel
    {        
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<PostModel> Posts { get; set; }
    }
}
