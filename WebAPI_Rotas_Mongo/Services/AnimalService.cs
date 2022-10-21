using MongoDB.Driver;
using System.Collections.Generic;
using WebAPI_Rotas_Mongo.Models;
using WebAPI_Rotas_Mongo.Utils;

namespace WebAPI_Rotas_Mongo.Services
{
    public class AnimalService
    {
        private readonly IMongoCollection<Animal> _animals;

        public AnimalService(IDatabaseSettings settings)
        {
            var dog = new MongoClient(settings.ConnectionString);
            var database = dog.GetDatabase(settings.DatabaseName);
            _animals = database.GetCollection<Animal>(settings.AnimalCollectionName);
        }

        public Animal Create(Animal dog)
        {
            _animals.InsertOne(dog);
            return dog;
        }

        public List<Animal> Get() => _animals.Find<Animal>(animal => true).ToList();

        public Animal Get(string id) => _animals.Find<Animal>(animal => animal.Id == id).FirstOrDefault();

        public List<Animal> GetByName(string name) => _animals.Find<Animal>(animal => animal.Name == name).ToList();

        public void Update(string id, Animal animalIn)
        {
            _animals.ReplaceOne(animal => animal.Id == id, animalIn);
        }

        public void Remove(Animal animalIn) => _animals.DeleteOne(animal => animal.Id == animalIn.Id);
    }
}

