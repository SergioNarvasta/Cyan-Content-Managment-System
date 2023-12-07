
using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Entities
{
    public class Component :Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentId { get; set; }
        public string? ComponentName { get; set; }

        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string? ComponentTitle { get; set; }
        public string? ComponentDescription { get; set; }
        public string? ComponentContent { get; set; }
        public int ComponentOrder { get; set; }
        public bool IsSlider { get; set; }
        public List<FileUnit>? Files { get; set; }
    }
}
