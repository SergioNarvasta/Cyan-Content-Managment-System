
using CyanCMS.Domain.Common;
using CyanCMS.Domain.Entities;

namespace CyanCMS.Domain.Dto
{
    public class CompanyDto : Actions
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<FileUnit>? Files { get; set; }
        public List<Component>? Components { get; set; } 
    }
}
