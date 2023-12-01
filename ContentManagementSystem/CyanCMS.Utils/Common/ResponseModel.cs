using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Utils.Common
{
    public class ResponseModel
    {
        public int Key { get; set; }
        public bool Status {  get; set; }
        public string Message { get; set; }
        public string Guid { get; set; }
    }
}
