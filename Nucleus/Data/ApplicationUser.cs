using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.Models;

namespace Nucleus.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; }
        public string PersonalSite { get; set; }

        public virtual ICollection<UserBadge> UserBadges { get; set; }
    }

    public class UserSocialNetwork
    {
        public Guid Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
