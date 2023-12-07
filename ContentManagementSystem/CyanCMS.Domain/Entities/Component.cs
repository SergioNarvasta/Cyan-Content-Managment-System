
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
        public string ComponentName { get; set; }

        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string ComponentTitle { get; set; }
        public string ComponentDescription { get; set; }
        public string ComponentContent { get; set; }
        public int ComponentOrder { get; set; }
        public bool IsActive { get; set; }
        public string IsSlider { get; set; } // 1 indica que es slider 0 solo mostrara una imagen
        public List<FileUnit> Files { get; set; }
    }
}
