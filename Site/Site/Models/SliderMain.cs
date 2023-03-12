
using CMS.Dominio.Comunes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Site.Models
{
    public class SliderMain : FileClass
    {
        [BsonId]
        public ObjectId SliderMain_Id { get; set; }

		public string SliderMain_Pk { get; set; }

		public string SliderMain_Titulo { get; set; }

        public string SliderMain_Descripcion { get; set; }

        public int SliderMain_Estado { get; set; }

        public int SliderMain_Orden { get; set; }
    }
}
