
using CMS.Dominio.Comunes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Site.Models
{
    public class ContentMain : FileClass
    {
        [BsonId]
        public ObjectId ContentMain_Id { get; set; }

        public string SliderMain_Titulo { get; set; }

        public string SliderMain_Descripcion { get; set; }

        public int SliderMain_Estado { get; set; }

        public int SliderMain_Orden { get; set; }
    }
}
