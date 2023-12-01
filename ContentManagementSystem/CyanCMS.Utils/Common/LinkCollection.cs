using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Utils.Common
{
    public class LinkCollection : List<Link>
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (Enumerator enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Link current = enumerator.Current;
                    stringBuilder.Append(current.ToString() + ",");
                }
            }

            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
