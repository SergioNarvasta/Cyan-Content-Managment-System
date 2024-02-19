
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CyanCMS.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.Domain.Entities
{
    public class Plan : Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; } = "Standar";

        [Column(TypeName = "varchar(50)")]
        public string? Description { get; set; }

        public int? CompanyQuantity { get; set; }

        [Required]
        [Precision(6,2)]
        public decimal Price {  get; set; }
        public DateTime? DateExpired { get; set; }
        public  User? User { get; set; }
    }
}
