using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nucleus.Models;

namespace Nucleus.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Badge> Badges { get; set; }

        public DbSet<UserBadge> UserBadges { get; set; }

        public DbSet<UserSocialNetwork> SocialNetworks { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagSet> TagSets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserBadge>()
                .HasKey(b => new { b.BadgeId, b.ApplicationUserId });
            
            builder.Entity<UserBadge>()
                .HasOne(ub => ub.Badge)
                .WithMany(b => b.UserBadges)
                .HasForeignKey(ub => ub.BadgeId);

            builder.Entity<UserBadge>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBadges)
                .HasForeignKey(ub => ub.ApplicationUserId);
                
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
