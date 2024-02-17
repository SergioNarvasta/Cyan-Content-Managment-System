

using CyanCMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CyanCMS.Domain.Entities
{
    public class PlanType : Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; } = "user";

        [Column(TypeName = "varchar(50)")]
        public string? Description { get; set; }
    }
}
