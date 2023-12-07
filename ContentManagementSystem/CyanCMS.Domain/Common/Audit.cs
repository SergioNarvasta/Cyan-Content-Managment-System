
namespace CyanCMS.Domain.Common
{
    public class Audit : Actions
    {
        public string? AuditCreateUser { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? AuditUpdateUser { get; set; }
        public DateTime AuditUpdateDate { get; set; }
    }
}
