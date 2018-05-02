using System;
using Nucleus.Data;

namespace Nucleus.Models
{
    /// <summary>
    /// An offer is something a member can do for someone else
    /// </summary>
    public class Offer
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public virtual Track Track { get; set; }
        public Credit Credits { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        public DateTime Ends { get; set; }

        public virtual ApplicationUser Member { get; set; }
    }
}