using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMS.Dominio.Entidades
{
    public class Experience
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Empresa { get; set; }

        public string Cargo { get; set; }

        public string Descripcion { get; set; }

        public string Fecha { get; set; }
        
        public string Skills {get;set;}
    }
}
