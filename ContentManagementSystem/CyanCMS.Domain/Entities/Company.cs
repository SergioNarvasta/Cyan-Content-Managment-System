
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
		public string User_Pk { get; set; }

	}
}
