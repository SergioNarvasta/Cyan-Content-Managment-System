
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CMS.Dominio.Comunes;

namespace CMS.Dominio.Entidades
{
    public class SliderSec : FileUnit
	{
        [BsonId]
        public ObjectId SliderSec_Id { get; set; }

		public string SliderSec_Pk { get; set; }

		public string SliderSec_Titulo { get; set; }

		public string SliderSec_Descripcion { get; set; }

		public int SliderSec_Estado { get; set; }

		public int SliderSec_Orden { get; set; }

		public string SliderSec_UsuarioPk { get; set; }

	


	}
}
