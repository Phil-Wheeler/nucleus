using Nucleus.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Glyph { get; set; }
        
        public virtual ICollection<ApplicationUser> User { get; set; }
    }
}
