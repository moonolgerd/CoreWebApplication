using Heroic.Shared;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApplication.Models
{
    public class HeroicContext : DbContext
    {
        public HeroicContext(DbContextOptions<HeroicContext> options)
            : base(options)

        {

        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Villain> Villains { get; set; }
    }
}
