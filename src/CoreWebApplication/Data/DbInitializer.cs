using CoreWebApplication.Models;
using System.Linq;

namespace CoreWebApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HeroicContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Heroes.Any())
            {
                var heroes = new Hero[]
                {
                    new Hero{Name="Carson",Age=10},
                    new Hero{Name="Meredith",Age=88},
                    new Hero{Name="Arturo",Age=35},
                    new Hero{Name="Gytis",Age=16},
                    new Hero{Name="Yan",Age=15},
                    new Hero{Name="Peggy",Age=20},
                    new Hero{Name="Laura",Age=40},
                    new Hero{Name="Nino", Age=30}
                };

                foreach (var s in heroes)
                {
                    context.Heroes.Add(s);
                }

                context.SaveChanges();
            }

            if (!context.Villains.Any())
            {
                var villains = new Villain[]
                {
                    new Villain{Name="Diablo",Level=10},
                    new Villain{Name="Lucifer",Level=88},
                    new Villain{Name="ArturPirozhkov",Level=35},
                    new Villain{Name="Nanny",Level=16},
                    new Villain{Name="Colt",Level=15}
                };

                foreach (var v in villains)
                {
                    context.Villains.Add(v);
                }

                context.SaveChanges();
            }
        }
    }

}
