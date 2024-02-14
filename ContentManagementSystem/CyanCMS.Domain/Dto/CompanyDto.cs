
using CyanCMS.Domain.Common;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Domain.Dto
{
    public class CompanyDto : Actions
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public List<FileUnit> Files { get; set; }
        public List<Component> Components { get; set; } 
    }
}
