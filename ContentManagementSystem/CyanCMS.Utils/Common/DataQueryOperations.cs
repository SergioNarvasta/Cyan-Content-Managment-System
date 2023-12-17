using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CyanCMS.Utils.Common
{
    public class DataQueryOperations
    {
        public static Dictionary<string, string> GetAttributeValues(string odataQueryString)
        {
            var attributeValues = new Dictionary<string, string>();
            var regex = new Regex(@"(\w+)\s+eq\s+(\w+)");
            var matches = regex.Matches(odataQueryString);

            foreach (Match match in matches)
            {
                if (match.Groups.Count == 3)
                {
                    var attributeName = match.Groups[1].Value;
                    var attributeValue = match.Groups[2].Value;
                    attributeValues[attributeName] = attributeValue;
                }
            }

            return attributeValues;
        }
    }
}
