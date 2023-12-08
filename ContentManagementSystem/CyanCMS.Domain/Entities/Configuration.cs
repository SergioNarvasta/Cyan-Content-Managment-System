
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CyanCMS.Domain.Entities
{
    public class Configuration 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfigurationId { get; set; }
        public string? MainColor { get; set; }
        public string? SecondaryColor { get; set;}

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public List<ConfigurationComponentType> ?ConfigurationComponentTypes { get; set;}
    }
}
