using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Utils.Common
{
    public class RepresentationCollectionPaged<T>
    {
        [JsonProperty(PropertyName = "_links")]
        public LinkCollection Links { get; set; }

        public IEnumerable<T> Items { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "rc")]
        public string ResponseContinuation { get; set; }

        public RepresentationCollectionPaged()
        {
            Links = new LinkCollection();
        }

        public RepresentationCollectionPaged(IPagedList<T> items)
            : this()
        {
            Items = items;
            TotalCount = items.TotalItemCount;
            ResponseContinuation = items.ResponseContinuation;
        }
    }
}
