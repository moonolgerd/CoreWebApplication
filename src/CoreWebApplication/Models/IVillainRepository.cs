using Heroic.Shared;
using System.Collections.Generic;

namespace CoreWebApplication.Models
{
    public interface IVillainRepository
    {
        void Add(Villain item);
        Villain Find(int id);
        IEnumerable<Villain> GetAll();
        void Remove(int id);
        void Update(Villain item);
    }
}