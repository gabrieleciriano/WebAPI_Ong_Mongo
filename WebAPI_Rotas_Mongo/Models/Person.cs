using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebAPI_Rotas_Mongo.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Animal Animal { get; set; }  
    }
}
