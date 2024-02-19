

using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
    [Table("File")]
    public class FileUnit :Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string? Description { get; set;}

        [Required]
        public string FileBase64 { get;set;} = string.Empty;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Size { get; set; } = string.Empty;

        public int? ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Component? Component { get; set; }

        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

    }
}
