using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class KingdomContext : DbContext
    {
        public DbSet<Kingdom> Kingdoms { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Hero> Heroes { get; set; }

        public KingdomContext(DbContextOptions options) : base(options)
        {

        }

    }
}