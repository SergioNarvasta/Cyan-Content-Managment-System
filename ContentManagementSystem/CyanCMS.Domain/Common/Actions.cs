
using System.ComponentModel;

namespace CyanCMS.Domain.Common
{
    public class Actions
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
