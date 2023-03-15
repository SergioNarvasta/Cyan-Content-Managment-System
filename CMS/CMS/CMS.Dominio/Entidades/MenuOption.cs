using MongoDB.Bson;

namespace CMS.Dominio.Entidades
{
	public class MenuOption
	{
		public ObjectId MenuOption_Id { get; set; }
		public string MenuOption_Nombre { get; set; }
        public int MenuOption_Estado { get; set; }
		public int MenuOption_Orden  { get; set; }
		public string Company_Pk { get; set; }
	}
}
