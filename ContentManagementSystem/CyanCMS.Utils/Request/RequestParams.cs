namespace CyanCMS.Utils.Request
{
    public class RequestParams : PageOptions
    { 
        public string Filters { get; set; }
        public string OrderBys { get; set; }
    }

    public class PageOptions
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
     }

    public class CompanyParams : PageOptions
    {
        public string CompanyName { get; set; } = string.Empty;
        public string IsActiveStr { get; set; } = string.Empty;
    }
}
