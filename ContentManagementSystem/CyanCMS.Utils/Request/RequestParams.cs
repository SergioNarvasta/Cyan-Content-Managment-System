﻿namespace CyanCMS.Utils.Request
{
    public class RequestParams : PageOptions
    { 
        public string Filters { get; set; }
        public string OrderBys { get; set; }
    }

    public class PageOptions
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
     }

    public class CompanyParams : PageOptions
    {
        public string CompanyName { get; set; } = string.Empty;
        public string IsActiveStr { get; set; } = string.Empty;
    }

    public class UserParams : PageOptions
    {
        public string UserName { get; set; } = string.Empty;
        public string IsActiveStr { get; set; } = string.Empty;
        public string RolId { get; set; } = string.Empty;
        public string PlanId { get; set; } = string.Empty;
    }

    public class ComponentParams : PageOptions
    {
        public string ComponentName { get; set; } = string.Empty;
        public string ComponentType { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string IsActiveStr { get; set; } = string.Empty;
    }
}
