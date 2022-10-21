using MongoDB.Driver;
using System.Collections.Generic;
using WebAPI_Rotas_Mongo.Models;
using WebAPI_Rotas_Mongo.Utils;

namespace WebAPI_Rotas_Mongo.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _people;

        public PersonService(IDatabaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DatabaseName);
            _people = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        public Person Create(Person person)
        {
            _people.InsertOne(person);
            return person;
        }

        public List<Person> Get() => _people.Find<Person>(person => true).ToList();

        public Person Get(string id) => _people.Find<Person>(person => person.Id == id).FirstOrDefault();

        public List<Person> GetByName(string name) => _people.Find<Person>(person => person.Name == name).ToList();

        public Person GetByAnimal(string id) => _people.Find(person => person.Animal.Id == id).FirstOrDefault();

        public void Update(string id, Person personIn)
        {
            _people.ReplaceOne(person => person.Id == id, personIn);
        }

        public void Remove(Person personIn) => _people.DeleteOne(person => person.Id == personIn.Id);
    }
}
