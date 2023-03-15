using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CMS.Dominio.Entidades
{
	public class Company
	{
		[BsonId]
		public ObjectId Company_Id { get; set; }
		public string Company_Pk { get; set; }
		public string Company_Nombre { get; set; }

		public string User_Pk { get; set; }

	}
}
