using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApplication.Models
{
    public interface IHeroRepository
    {
        void Add(Hero item);
        IEnumerable<Hero> GetAll();
        Hero Find(int id);
        void Remove(int id);
        void Update(Hero item);
    }
}
