using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nucleus.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext appContext)
        {
            // Get an instance of the DbContext from the DI container
            //using (var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())

                // perform database delete
                //context.Database.EnsureDeleted();

                //... perform other seed operations
                SeedTracks(appContext);

                appContext.SaveChanges();
        }

        private static void SeedTracks(ApplicationDbContext context)
        {
            context.Tracks.AddRange(
                new Track { Name = "Technical" },
                new Track { Name = "Leadership" },
                new Track { Name = "Entrepreneurship" },
                new Track { Name = "Support" }
            );
            context.SaveChanges();
        }

        private static void SeedTags(ApplicationDbContext context)
        {
            context.Tags.AddRange(
                new Tag { Name = "Male" },
                new Tag { Name = "Female" },
                new Tag { Name = "Non-binary" },
                new Tag { Name = "Asian" },
                new Tag { Name = "Pakeha" },
                new Tag { Name = "Pasifika" },
                new Tag { Name = "Māori" }
            );
            context.SaveChanges();
        }
    }
}