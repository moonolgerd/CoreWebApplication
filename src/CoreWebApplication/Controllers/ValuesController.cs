using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        #region Fields

        private static int _counter;
        private static readonly Random _random = new Random();
        private static readonly Dictionary<int, Hero> _heroes = new Dictionary<int, Hero>();

        #endregion
        static ValuesController()
        {
            _counter = 15;
            for (var i = 1; i <= _counter; i++)
                _heroes.Add(i, new Hero(i) { Name = $"Hero{i}", Age = _random.Next(15, 90) });
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _heroes.Values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return _heroes[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _heroes.Add(++_counter, new Hero(_counter) { Name = value });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            if (_heroes.ContainsKey(id))
                _heroes[id].Name = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_heroes.ContainsKey(id))
                _heroes.Remove(id);
        }
    }

    public class Hero
    {
        public Hero(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; } = "Oleg";
        public int Age { get; set; } = 35;
    }
}
