using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Models
{
    /// <summary>
    /// Tags are a taxonomical collection intended to describe personal circumstances such as current or aspirational roles, community allyships, etc.
    /// </summary>
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Tag sets help categorise tags into common groups or uses such as "Ethnicity", "Sexual Orientation", "Occupation", etc.
    /// </summary>
    public class TagSet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
