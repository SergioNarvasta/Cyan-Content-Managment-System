
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
	public class Company 
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        public string? CompanyName { get; set; }
		public string? CompanyAdress { get; set; }

        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string? CompanyPhoneNumber { get; set; }
		public string? CompanyEmail { get; set; }

        public List<FileUnit>? Files { get; set; }

        public List<Component>? Components { get; set; }

        public int User_Id_Fk { get; set; }
		public User User { get; set; }	
	}
}
