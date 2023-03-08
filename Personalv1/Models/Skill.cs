using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Personal.Models
{
    public class Skill : Audit
    {
        [BsonId]
        public ObjectId Skill_Id { get; set; }

        public string Skill_Nombre { get; set; }

        public string Skill_Version {get; set;}

        public string Skill_URLImagen {get;set;}
    }
}