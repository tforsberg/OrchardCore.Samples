using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Module1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        static List<Person> _person = new List<Person>() { 
            new Person() { Id = 1, FirstName="Todd", LastName="Forsberg", IsActive=true},
            new Person() { Id = 2, FirstName="John", LastName="Doe", IsActive=true}
        };

        public PersonController()
        {
        }

        // GET: api/<PersonController>
        [HttpGet]
        public List<Person> Get()
        {
            return _person.ToList();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person r = new Person();

            foreach (Person person in _person)
            {
                if (person.Id == id)
                {
                    r = person;
                }
            }
                
            return r;
        }

        // POST api/<PersonController>      // This method is not working //
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public void Post([FromBody] Person person)
        {
            _person.Add(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        [IgnoreAntiforgeryToken]
        public void Put(int id, [FromBody] Person value)
        {
            var person = _person.SingleOrDefault(p => p.Id == id);
            if (person != null)
            {
                person.FirstName = value.FirstName;
                person.LastName = value.LastName;
                person.IsActive = value.IsActive;
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        [IgnoreAntiforgeryToken]
        public void Delete(int id)
        {
            var person = _person.SingleOrDefault(p => p.Id == id);
            if (person != null)
                _person.Remove(person);
        }
    }
}
