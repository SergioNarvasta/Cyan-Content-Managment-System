
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Site.Models.Comunes;

namespace Site.Models
{
    public class SliderMain : FileClass
    {
        [BsonId]
        public ObjectId SliderMain_Id { get; set; }
		public string SliderMain_Pk { get; set; }
		public string SliderMain_Titulo { get; set; }
        public string SliderMain_Descripcion { get; set; }
        public int    SliderMain_Estado { get; set; }
        public int    SliderMain_Orden { get; set; }
        public string SliderMain_Slider { get; set; }
        public string Company_Pk { get; set; }
    }
}
