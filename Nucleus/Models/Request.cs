using System;
using Nucleus.Data;

namespace Nucleus.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Credit Credit { get; set; }

        public Recurrence Recurrence { get; set; }
        public bool IsActive { get; set; }
        public virtual Track Track { get; set; }

        public Guid Member { get; set; }
    }
}