
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CyanCMS.Domain.Common;


namespace CyanCMS.Domain.Entities
{
    public class ComponentType : Actions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "varchar(80)")]
        public string? Description { get; set; }

        public Component? Component { get; set; } //1 to 1

        public ConfigurationComponentType? ConfigurationComponentType { get; set; }
    }
}
