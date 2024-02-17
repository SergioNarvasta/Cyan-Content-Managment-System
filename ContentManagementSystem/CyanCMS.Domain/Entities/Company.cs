
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
	public class Company :Audit
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = "CompanyEmpty";

        [Column(TypeName = "varchar(50)")]
        public string? Adress { get; set; }

        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        [Column(TypeName = "varchar(15)")]
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string? Email { get; set; }

        public List<FileUnit>? Files { get; set; }

        public List<Component>? Components { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public Configuration? Configuration { get; set; }
    }
}
