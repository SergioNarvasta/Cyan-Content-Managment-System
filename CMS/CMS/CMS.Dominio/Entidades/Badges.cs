using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CMS.Dominio.Entidades
{
    public class Badges
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Nombre { get; set; }

        public string Entidad { get; set; }

        public string Descripcion { get; set; }
        
        public string Fecha { get; set; }
        
        public string Url {get;set;}
        
       
    }
}
