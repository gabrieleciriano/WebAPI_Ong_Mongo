using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI_Rotas_Mongo.Models;
using WebAPI_Rotas_Mongo.Services;

namespace WebAPI_Rotas_Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly AnimalService _animalService;

        public PersonController(PersonService personService, AnimalService animalService)
        {
            _personService = personService;
            _animalService = animalService;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get() => _personService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPerson")]
        public ActionResult<Person> Get(string id)
        {
            var person = _personService.Get(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet("{name}", Name = "GetNamePerson")]
        public ActionResult<Person> GetByName(string name)
        {
            var person = _personService.GetByName(name);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet("animal/{id:length(24)}", Name = "GetPersonByAnimal")]
        public ActionResult<Person> GetByAnimal(string id)
        {
            var person = _personService.GetByAnimal(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            Animal animal = _animalService.Create(person.Animal);
            person.Animal = animal;
            _personService.Create(person);
            return CreatedAtRoute("GetPerson", new { id = person.Id.ToString() }, person);
        }

        [HttpPut]
        public ActionResult<Person> Put(Person personIn, string id)
        {
            var person = _personService.Get(id);
            if (person == null)
                return NotFound();

            personIn.Id = id;
            _personService.Update(personIn.Id, personIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Person> Delete(string id)
        {
            Person person = _personService.Get(id);
            if (person == null)
                return NotFound();

            _personService.Remove(person);
            return NoContent();
        }
    }
}