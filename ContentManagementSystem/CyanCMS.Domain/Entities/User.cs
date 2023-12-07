
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CyanCMS.Domain.Entities
{
	public class User : Audit
	{
		[Key]
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string UserAdress { get; set; }
        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string UserPhoneNumber { get; set; }
		public string UserEmail { get; set; }
		public string UserToken { get; set; }
		public string PlanId { get; set; }

		public int RolId { get; set; }
		public Rol Rol { get; set; }
	}
}
