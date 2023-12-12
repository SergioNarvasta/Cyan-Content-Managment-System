
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
        public string ComponentTypeName { get; set; } = string.Empty;
        public string? ComponentTypeDescription { get; set; }

        public Component? Component { get; set; } //1 to 1

        public ConfigurationComponentType? ConfigurationComponentType { get; set; }
    }
}
