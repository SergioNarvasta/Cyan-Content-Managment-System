using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Personal.Models
{
    public class Skill
    {
       [BsonId]
        public ObjectId Id { get; set; }

        public string Nombre { get; set; }

        public string Version {get; set;}

        public string Icono {get;set;}
    }
}