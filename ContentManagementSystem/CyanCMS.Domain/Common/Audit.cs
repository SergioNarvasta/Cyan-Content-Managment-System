
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyanCMS.Domain.Common
{
    public class Audit : Actions
    {
        [DefaultValue("System")]
        public string AuditCreateUser { get; set; } = "System";
        public DateTime AuditCreateDate { get; set; }= DateTime.Now;

        [Column(TypeName = "varchar(50)")]
        public string? AuditUpdateUser { get; set; }
        public DateTime? AuditUpdateDate { get; set; }
    }
}
