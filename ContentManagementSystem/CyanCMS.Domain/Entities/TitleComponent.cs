using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using CMS.Dominio.Comunes;

namespace CMS.Dominio.Entidades
{
	public class TitleComponent :Audit
	{
		[BsonId]
		public ObjectId TitleComponent_Id { get; set; }
		public string TitleComponent_Pk { get; set; }
		public string Title_ContentMain { get; set; }
		public string Title_ContentSec { get; set; }
		public string Title_Aside { get; set; }
		public string Title_SliderSmall { get; set; }
		public string Title_SliderSec { get; set; }
		public string Title_Partners { get; set; }
		public string Title_Footer { get; set; }

		public string Company_Pk { get; set; }
	}
}
