using CMS.Dominio.Common;
using CyanCMS.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CyanCMS.Domain.Entities
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
		public string Company_Pk { get; set; }	
        public string SliderMain_Slider { get; set; } // 1 indica que es slider 0 solo mostrara una imagen
	}
}
