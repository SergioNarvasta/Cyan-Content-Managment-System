
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
	public class User : Audit
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string UserLastName { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string UserAdress { get; set; }

        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public string UserPhoneNumber { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserToken { get; set; }

        public List<Company>? Companies { get; set; }

        [NotMapped]
        public Plan? Plan { get; set; }

        [NotMapped]
        public Rol? Rol { get; set; }
		
	}
}
