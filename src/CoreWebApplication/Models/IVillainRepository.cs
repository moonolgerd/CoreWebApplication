using Heroic.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApplication.Models
{
    public interface IVillainRepository
    {
        Task Add(Villain item);
        Villain Find(int id);
        IEnumerable<Villain> GetAll();
        Task Remove(int id);
        Task Update(Villain item);
    }
}