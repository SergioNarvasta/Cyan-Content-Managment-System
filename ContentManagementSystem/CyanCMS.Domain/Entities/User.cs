
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
	public class User : IdentityUser
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
        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 80 caracteres")]
        public string UserAdress { get; set; }

        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public string UserPhoneNumber { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserToken { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public string? AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? AuditUpdateUser { get; set; }
        public DateTime AuditUpdateDate { get; set; }


        public List<Company>? Companies { get; set; }

        [NotMapped]
        public Plan? Plan { get; set; }

        [NotMapped]
        public Rol? Rol { get; set; }
		
	}
}
