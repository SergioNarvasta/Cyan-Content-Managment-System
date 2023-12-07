
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CyanCMS.Domain.Common;


namespace CyanCMS.Domain.Entities
{
    public class ComponentType : Actions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentTypeId { get; set; }

        [Required]
        public string ComponentTypeName { get; set; }
        public string? ComponentTypeDescription { get; set; }

        public int ComponentId { get; set; }

        [ForeignKey("ComponentId")]
        public Component? Component { get; set; }
        public ConfigurationComponentType? ConfigurationComponentType { get; set; }
    }
}
