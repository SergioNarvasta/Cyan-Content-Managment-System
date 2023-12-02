
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CyanCMS.Domain.Entities
{
	public class Rol : Audit
	{
        [Key]
        public int Rol_Id { get; set; }
		public string Rol_Pk { get; set; }
		public string Rol_Nombre { get; set; }
		public string Rol_Descripcion { get; set; }
		public int Rol_Estado { get; set; }
	}
}
