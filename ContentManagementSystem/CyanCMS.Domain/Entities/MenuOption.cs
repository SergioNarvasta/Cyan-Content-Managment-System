using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CyanCMS.Domain.Entities
{
	public class MenuOption
	{
		[BsonId]
		public ObjectId MenuOption_Id { get; set; }
		public string MenuOption_Pk { get; set; }
		public string MenuOption_Nombre { get; set; }
        public int MenuOption_Estado { get; set; }
		public int MenuOption_Orden  { get; set; }
		public string Company_Pk { get; set; }
	}
}
