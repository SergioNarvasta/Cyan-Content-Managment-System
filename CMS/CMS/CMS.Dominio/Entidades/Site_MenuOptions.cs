using MongoDB.Bson;

namespace CMS.Dominio.Entidades
{
	public class SiteMenuOptions
	{
		public ObjectId MenuOptions_Id { get; set; }
		public string MenuOptions_Nombre { get; set; }
        public int MenuOptions_Estado { get; set; }
		public int MenuOptions_Orden  { get; set; }
	}
}
