
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CyanCMS.Domain.Common;


namespace CyanCMS.Domain.Entities
{
    public class ConfigurationComponentType : Actions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigurationComponentTypeId { get; set; }

        public int ConfigurationId { get; set; }

        [ForeignKey("ConfigurationId")]
        public Configuration? Configuration { get; set; }

        public int ComponentTypeId { get; set; }

        [ForeignKey("ComponentTypeId")]
        public ComponentType? ComponentType { get; set; }
    }
}
