
namespace CyanCMS.Utils.Response
{
    public class DataPaginationRp
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 0;
        public int PageCount => (int)Math.Ceiling((double)TotalCount / PageSize);
        public string BaseURL { get; set; }
    }

    public class DataPaginationRp<T> : DataPaginationRp
    {
        public IEnumerable<T> Elements { get; set; }
    }
}
