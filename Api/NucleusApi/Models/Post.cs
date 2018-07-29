using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NucleusApi.Models
{
    public class Post
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created => DateTime.Now;
        public DateTime Accepted { get; set; }
        public DateTime Closed { get; set; } 
        public Guid Owner { get; set; }
        public Guid AcceptedBy { get; set; }
    }    

    public enum PostType { Offer, Request, Comment }
}
