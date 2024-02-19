
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Common
{
    public class Audit : Actions
    {
        [DefaultValue("System")]
        [Column(TypeName = "varchar(20)")]
        public string AuditCreateUser { get; set; } = "System";
        public DateTime AuditCreateDate { get; set; }= DateTime.Now;

        [Column(TypeName = "varchar(20)")]
        public string? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
    }
}
