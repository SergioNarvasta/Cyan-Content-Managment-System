

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using CMS.Dominio.Comunes;

namespace CyanCMS.Domain.Entities
{
	public class Rol : Audit
	{
		[BsonId]
		public ObjectId Rol_Id { get; set; }
		public string Rol_Pk { get; set; }
		public string Rol_Nombre { get; set; }
		public string Rol_Descripcion { get; set; }
		public int Rol_Estado { get; set; }
	}
}
