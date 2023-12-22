

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
        public int FiledId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string FileName { get; set; } = string.Empty;
        public string? FileDescription { get; set;}

        [Required]
        public string FileBase64 { get;set;} = string.Empty;

        [Required]
        public string FileSize { get; set; } = string.Empty;

        public int? ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Component? Component { get; set; }

        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

    }
}
