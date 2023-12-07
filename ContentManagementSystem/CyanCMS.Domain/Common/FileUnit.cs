

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
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string FileName { get; set; }
        public string FileDescription { get; set;}
        public string FileBase64 { get;set;}
        public string FileSize { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public int ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Component Component { get; set; }

    }
}
