using System;
using System.Collections.Generic;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        #region Fields

        private static readonly Random _random = new Random();
        private static readonly Dictionary<int, Hero> _heroes = new Dictionary<int, Hero>();

        #endregion

        static HeroesController()
        {
            for (var i = 1; i <= 15; i++)
                _heroes.Add(i, new Hero(i) { Name = $"Hero{i}", Age = _random.Next(15, 90) });
        }

        // GET api/heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _heroes.Values;
        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return _heroes[id];
        }

        // POST api/heroes
        [HttpPost]
        public void Post([FromBody]Hero hero)
        {
            if (!_heroes.ContainsKey(hero.Id))
                _heroes.Add(hero.Id, hero);
        }

        // PUT api/heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hero hero)
        {
            if (_heroes.ContainsKey(id))
            {
                _heroes[id].Name = hero.Name;
                _heroes[id].Age = hero.Age;
            }
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_heroes.ContainsKey(id))
                _heroes.Remove(id);
        }
    }
}
