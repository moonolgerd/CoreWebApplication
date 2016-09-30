using System;
using System.Collections.Generic;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class VillainsController : Controller
    {
        private static int _counter;
        private static readonly Dictionary<int, Villain> _villains;

        static VillainsController()
        {
            _villains = new Dictionary<int, Villain> {
                [11] = new Villain(11) { Name = "Diablo", Level = 100 },
                [12] = new Villain(12) { Name = "Shodan", Level = 256 },
                [13] = new Villain(13) { Name = "Joker", Level = 50 },
                [666] = new Villain(666) { Name = "Wild Hunt", Level = 99999 }
            };
        }

        [HttpGet]
        public IEnumerable<Villain> Get()
        {
            return _villains.Values;
        }

        [HttpGet("{id}")]
        public Villain Get(int id)
        {
            return _villains[id];
        }

        // POST api/heroes
        [HttpPost]
        public void Post([FromBody]Villain villain)
        {
            _villains.Add(++_counter, villain);
        }

        // PUT api/heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Villain villain)
        {
            if (_villains.ContainsKey(id))
            {
                _villains[id].Name = villain.Name;
                _villains[id].Level = villain.Level;
                _villains[id].Role = villain.Role;
            }
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_villains.ContainsKey(id))
                _villains.Remove(id);
        }
    }
}