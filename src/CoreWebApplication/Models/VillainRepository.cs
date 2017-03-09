using Heroic.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreWebApplication.Models
{
    public class VillainRepository : IVillainRepository
    {
        private HeroicContext _context;

        public VillainRepository(HeroicContext context)
        {
            _context = context;
        }

        public void Add(Villain item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public Villain Find(int id)
        {
            return _context.Villains.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Villain> GetAll()
        {
            return _context.Villains.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Villains.First(t => t.Id == id);
            _context.Villains.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Villain item)
        {
            _context.Villains.Update(item);
            _context.SaveChanges();
        }
    }
}
