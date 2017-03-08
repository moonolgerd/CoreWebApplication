using System.Collections.Generic;
using System.Linq;

namespace CoreWebApplication.Models
{
    public class HeroRepository : IHeroRepository
    {
        private HeroicContext _context;

        public HeroRepository(HeroicContext context)
        {
            _context = context;
        }

        public void Add(Hero item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public Hero Find(int id)
        {
            return _context.Heroes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Hero> GetAll()
        {
            return _context.Heroes.ToList();
        }

        public void Remove(int id)
        {
            var entity = _context.Heroes.First(t => t.Id == id);
            _context.Heroes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Hero item)
        {
            _context.Heroes.Update(item);
            _context.SaveChanges();
        }
    }
}
