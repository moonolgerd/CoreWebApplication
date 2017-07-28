using System;
using System.Collections.Generic;
using CoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Heroic.Shared;

namespace CoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private readonly IHeroRepository _heroes;

        public HeroesController(IHeroRepository heroes)
        {
            _heroes = heroes;
        }    

        // GET api/heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _heroes.GetAll();
        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return _heroes.Find(id);
        }

        // POST api/heroes
        [HttpPost]
        public void Post([FromBody]Hero hero)
        {
            if (_heroes.Find(hero.Id) == null)
                _heroes.Add(hero);
        }

        // PUT api/heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hero hero)
        {
            var existing = _heroes.Find(hero.Id);
            if (existing != null)
            {
                existing.Name = hero.Name;
                existing.Age = hero.Age;
                existing.Gender = hero.Gender;
                _heroes.Update(existing);
            }
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_heroes.Find(id) != null)
                _heroes.Remove(id);
        }
    }
}
