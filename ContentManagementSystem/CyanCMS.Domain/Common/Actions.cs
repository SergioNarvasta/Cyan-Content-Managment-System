
using System.ComponentModel;

namespace CyanCMS.Domain.Common
{
    public class Actions
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
