using System;

namespace Nucleus.Models
{
    /// <summary>
    /// An acceptance represents an agreement for an offer or a request, recorded as the AgreementId. 
    /// The agreement is between two members for a set period of time, for a set credit.
    /// </summary>
    public class Acceptance
    {
        public Guid Id { get; set; }
        public Guid AgreementId { get; set; }
        public DateTime AcceptedOn { get; set; }
        public DateTime? EndedOn { get; set; }
    }
}