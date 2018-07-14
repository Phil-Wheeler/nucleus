using Microsoft.EntityFrameworkCore;
using NucleusApi.Models;

namespace NucleusApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}