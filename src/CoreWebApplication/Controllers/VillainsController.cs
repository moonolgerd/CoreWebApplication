using System.Collections.Generic;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Heroic.Shared;

namespace CoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class VillainsController : Controller
    {
        private IVillainRepository _villains;

        public VillainsController(IVillainRepository villains)
        {
            _villains = villains;
        }
               
        [HttpGet]
        public IEnumerable<Villain> Get()
        {
            return _villains.GetAll();
        }

        [HttpGet("{id}")]
        public Villain Get(int id)
        {
            return _villains.Find(id);
        }

        [HttpPost]
        public void Post([FromBody]Villain villain)
        {
            if (_villains.Find(villain.Id) == null)
                _villains.Add(villain);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Villain villain)
        {
            var existing = _villains.Find(villain.Id);
            if (existing != null)
            {
                existing.Name = villain.Name;
                existing.Level = villain.Level;
                existing.Role = villain.Role;
                _villains.Update(existing);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_villains.Find(id) != null)
                _villains.Remove(id);
        }
    }
}