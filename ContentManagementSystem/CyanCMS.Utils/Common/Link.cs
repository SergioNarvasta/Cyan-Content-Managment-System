using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Utils.Common
{
   public class Link
    {
        public static readonly string Name = "Link";

        public string target { get; set; }

        public string rel { get; set; }

        public string title { get; set; }

        public override string ToString()
        {
            string text = "<" + target + ">";
            if (!string.IsNullOrWhiteSpace(rel))
            {
                text = text + ";rel=\"" + rel + "\"";
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                text = text + ";title=\"" + title + "\"";
            }

            return text;
        }
    }
}
