
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
        public string ComponentName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres")]
        public string ComponentTitle { get; set; } = string.Empty;
        public string ComponentDescription { get; set; } = string.Empty;
        public string ComponentContent { get; set; } = string.Empty;
        public int ComponentOrder { get; set; }
        public int ComponentStyle { get; set; } 
        public bool IsSlider { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        public int ComponentTypeId { get; set; }

        [ForeignKey("ComponentTypeId")]
        public ComponentType? ComponentType { get; set; }
        

        public List<FileUnit>? Files { get; set; }
    }
}
