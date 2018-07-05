using System;
using Nucleus.Data;

namespace Nucleus.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Accepted { get; set; }
        public DateTime Closed { get; set; } 
        public ApplicationUser Owner { get; set; }
        public ApplicationUser AcceptedBy { get; set; }
    }    
}
