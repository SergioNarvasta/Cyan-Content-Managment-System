
using CyanCMS.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
	public class User : Audit
    {
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; } = string.Empty;

        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 80 caracteres")]
        [Column(TypeName = "varchar(80)")]
        public string? LastName { get; set; }

        [MaxLength(80, ErrorMessage = "El campo no debe de tener mas de 80 caracteres")]
        [Column(TypeName = "varchar(80)")]
        public string? Adress { get; set; }

        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        [Column(TypeName = "varchar(15)")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; } 

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.Password)]
        public string Token { get; set; }

        public List<Company>? Companies { get; set; }

        public int? PlanId { get; set; }
        [ForeignKey("PlanId")]
        public Plan? Plan { get; set; }

        public int? RolId { get; set; }

        [ForeignKey("RolId")]
        public Rol? Rol { get; set; }
    }
}
