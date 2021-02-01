using System.Collections.Generic;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Heroic.Shared;
using System.Threading.Tasks;

namespace CoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillainsController : ControllerBase
    {
        private readonly IVillainRepository _villains;

        public VillainsController(IVillainRepository villains) => _villains = villains ?? throw new System.ArgumentNullException(nameof(villains));

        [HttpGet]
        public IEnumerable<Villain> Get() => _villains.GetAll();

        [HttpGet("{id}")]
        public Villain Get(int id) => _villains.Find(id);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Villain villain)
        {
            if (ModelState.IsValid)
            {
                if (_villains.Find(villain.Id) == null)
                    await _villains.Add(villain);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Villain villain)
        {
            var existing = _villains.Find(id);
            if (existing != null)
            {
                existing.Name = villain.Name;
                existing.Level = villain.Level;
                existing.Role = villain.Role;
                await _villains.Update(existing);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_villains.Find(id) != null)
            {
                await _villains.Remove(id);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}