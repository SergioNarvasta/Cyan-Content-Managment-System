

using CyanCMS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Common
{
    public class FileUnit :Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FiledId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string FileName { get; set; }
        public string? FileDescription { get; set;}

        [Required]
        public string FileBase64 { get;set;}

        [Required]
        public string FileSize { get; set; } 

        public int? ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Component? Component { get; set; }

        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

    }
}
