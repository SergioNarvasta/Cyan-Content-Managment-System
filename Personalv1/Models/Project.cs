using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Personal.Models
{
    public class Project
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Link { get; set; }

        public IFormFile Archivo { get; set; }
        public string RutaArchivo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string UsuarioRegistro { get; set; }
    }
}
