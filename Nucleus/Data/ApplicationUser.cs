using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.Models;

namespace Nucleus.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; }

        [Display(Name = "Personal Site")]
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
