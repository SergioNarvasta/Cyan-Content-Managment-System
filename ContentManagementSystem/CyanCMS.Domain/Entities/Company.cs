
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CyanCMS.Domain.Entities
{
	public class Company : FileUnit
	{
		[Key]
		public int Company_Id { get; set; }
		public string Company_Pk { get; set; }
		public string Company_Nombre { get; set; }
		public string Company_Direccion { get; set; }
		public int Company_Telefono { get; set; }
		public string Company_Email { get; set; }
		public int Company_Estado { get; set; }
		public string Plan_Pk {get;set;}

		public int User_Id_Fk { get; set; }
		public User User { get; set; }	
	}
}
