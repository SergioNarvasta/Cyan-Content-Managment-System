using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Common;
using CyanCMS.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace CyanCMS.WebPlatform.Controllers
{
    public class ComponentController : Controller
    {
        [HttpGet]
        public IActionResult Index(RequestParams @params)
        {
            string componentNameFilter = string.Empty;
            string componentTypeFilter = string.Empty;
            string companyIdFilter     = string.Empty;
            string componentIsActiveFilter = string.Empty;

            var queryParams = new ComponentParams();

            if (@params.Filters != null)
            {
                var attributeValues = DataQueryOperations.GetAttributeValues(@params.Filters);
                foreach (var attribute in attributeValues)
                {
                    if (attribute.Key == "componentName")
                    {
                        componentNameFilter = attribute.Value;
                    }
                    else if (attribute.Key == "componentTypeFilter")
                    {
                        componentTypeFilter = attribute.Value;
                    }
                    else if (attribute.Key == "companyId")
                    {
                        companyIdFilter = attribute.Value;
                    }
                    else if (attribute.Key == "isActive")
                    {
                        componentIsActiveFilter = attribute.Value;
                    }
                }
                ComponentParams companyParams = new()
                {
                    ComponentName = componentNameFilter,
                    ComponentType = componentTypeFilter,
                    CompanyId     = companyIdFilter,
                    IsActiveStr   = componentIsActiveFilter,
                    PageSize      = @params.PageSize,
                    PageNumber    = @params.PageNumber,
                };
                queryParams = companyParams;
            }
            return View();
        }
    }
}
