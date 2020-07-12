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
        List<Person> _person = new List<Person>();

        public PersonController()
        {
            // Sample Data //
            var a = new Person();
            a.Id = 1;
            a.FirstName = "Todd";
            a.LastName = "Forsberg";
            a.IsActive = true;

            var b = new Person();
            b.Id = 2;
            b.FirstName = "John";
            b.LastName = "Doe";
            b.IsActive = true;

            _person.Add(a);
            _person.Add(b);

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
        public void Post([FromBody] Person person)
        {
            _person.Add(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
