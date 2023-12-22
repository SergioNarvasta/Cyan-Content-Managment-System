
using CyanCMS.Domain.Entities;

namespace CyanCMS.Utils.Request
{
    public class RequestModels
    {
        public class CreateCompanyModel {
            public Company Company { get; set; }
            public FileUnit File { get; set; }
            
        }

        public class CreateComponentModel
        {
            public Component Component { get; set; }
            public List<FileUnit> Files { get; set; }

        }
    }
}
