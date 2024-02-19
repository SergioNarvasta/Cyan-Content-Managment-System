
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CyanCMS.Domain.Entities
{
    public class Configuration 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? MainColor { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? SecondaryColor { get; set;}
        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public List<ConfigurationComponentType> ?ConfigurationComponentTypes { get; set;}
    }
}
