using System;

namespace Nucleus.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } 
        public string Name { get; set; }
        public DateTime Awarded { get; set; }
        public int Level { get; set; }       
    }
}