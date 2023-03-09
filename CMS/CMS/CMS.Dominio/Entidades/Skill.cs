using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMS.Dominio.Entidades
{
    public class Skill : Audit
    {
        [BsonId]
        public ObjectId Skill_Id { get; set; }

        public string Skill_Nombre { get; set; }

        public string Skill_Version {get; set;}

        public string Skill_URLImagen {get;set;}
        public string Skill_URLDrive { get; set; }

        public int Skill_Orden { get; set; }

        public int Skill_Estado { get; set; }
    }
}