using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.DTO
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
