using Heroic.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApplication.Models
{
    public class VillainRepository : IVillainRepository
    {
        private readonly HeroicContext _context;

        public VillainRepository(HeroicContext context) => _context = context;

        public async Task Add(Villain item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Villain Find(int id) => _context.Villains.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Villain> GetAll() => _context.Villains.ToList();

        public async Task Remove(int id)
        {
            var entity = _context.Villains.First(t => t.Id == id);
            _context.Villains.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Villain item)
        {
            _context.Villains.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
