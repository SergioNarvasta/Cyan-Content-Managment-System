using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Site.Models.Comunes;

namespace Site.Models
{
    public class ContentMain : FileUnit
    {
        [BsonId]
        public ObjectId ContentMain_Id { get; set; }
        public string ContentMain_Pk { get; set; }
        public string ContentMain_Titulo { get; set; }
        public string ContentMain_Descripcion { get; set; }
        public string ContentMain_Contenido { get; set; }
        public int    ContentMain_Estado { get; set; }
        public int    ContentMain_Orden { get; set; }
        public string Company_Pk { get; set; }
    }
}
