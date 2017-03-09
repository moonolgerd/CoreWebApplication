using Heroic.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
