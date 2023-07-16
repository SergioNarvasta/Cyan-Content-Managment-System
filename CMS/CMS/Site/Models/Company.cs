using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Site.Models.Comunes;

namespace Site.Models
{
	public class Company : FileUnit
	{
		[BsonId]
		public ObjectId Company_Id { get; set; }
		public string Company_Pk { get; set; }
		public string Company_Nombre { get; set; }
		public string Company_Direccion { get; set; }
		public int    Company_Telefono { get; set; }
		public string Company_Email { get; set; }
		public int    Company_Estado { get; set; }
		public string Plan_Pk { get; set; }
		public string User_Pk { get; set; }

	}
}
