using System;

namespace NucleusApi.Models
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
        public Guid Owner { get; set; }
        public Guid AcceptedBy { get; set; }
    }    

    public enum PostType { Offer, Comment, Request }
}
