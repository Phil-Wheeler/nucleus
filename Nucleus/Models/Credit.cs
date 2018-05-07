using System;

namespace Nucleus.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public int Unit { get; set; }
        public Recurrence Recurrence { get; set; }

        //public virtual Offer Offer { get; set; }
    }

    public enum Recurrence {
        Once,
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Informal
    }
}