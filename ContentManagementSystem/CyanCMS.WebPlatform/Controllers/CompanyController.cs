
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Common;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using static CyanCMS.Utils.Common.Enums;
using static CyanCMS.Utils.Request.RequestModels;

namespace CyanCMS.WebPlatform.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyAppService _companyAppService;
        private readonly IConfigurationAppService _configurationAppService;
        private readonly IComponentTypeAppService _componentTypeAppService;
        private readonly IConfigurationComponentTypeAppService _configComponentTypeAppService;
        private readonly IFileAppService _fileAppService;

        public CompanyController(ICompanyAppService companyAppService, 
            IConfigurationAppService configurationAppService,
            IComponentTypeAppService componentTypeAppService,
            IConfigurationComponentTypeAppService configurationComponentTypeAppService,
            IFileAppService fileAppService) 
        {
			_companyAppService = companyAppService;
            _configurationAppService = configurationAppService;
            _componentTypeAppService = componentTypeAppService;
            _configComponentTypeAppService = configurationComponentTypeAppService;
            _fileAppService = fileAppService;
        }
       
        [HttpGet]
        public async Task<IActionResult> Index(RequestParams @params)
        {
            string companyNameFilter = string.Empty;
            string companyIsActiveFilter = string.Empty;
            var queryParams = new CompanyParams();

            if (@params != null) {
                var attributeValues = DataQueryOperations.GetAttributeValues(@params.Filters);
                foreach (var attribute in attributeValues)
                {
                    if (attribute.Key == "companyName") {
                        companyNameFilter = attribute.Value;
                    }
                     else if (attribute.Key == "isActive")
                    {
                        companyIsActiveFilter = attribute.Value;
                    }
                }
                CompanyParams companyParams = new CompanyParams
                {
                    CompanyName = companyNameFilter,
                    IsActiveStr = companyIsActiveFilter,
                    PageSize = @params.PageSize,
                    PageNumber = @params.PageNumber,
                };
                queryParams = companyParams;
            }

            var data = await _companyAppService.GetAll(queryParams);
            int totalCount = _companyAppService.GetTotalCount();

            DataPaginationRp dataPaginationRp = new DataPaginationRp<Company>() {
                PageNumber = @params.PageNumber,
                PageSize   = @params.PageSize,
                TotalCount = totalCount,
                Elements   = data,
                BaseURL    = Url.Action(),
            };

            return View(dataPaginationRp);
        }

        [HttpPost]
        public async Task<IActionResult> GetCompanyById(string User_Pk)
        {
            return Ok(await _companyAppService.GetById(User_Pk));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyModel createCompany)
        {
            if (createCompany.Company == null)
                return BadRequest();

            var resultCompany = await _companyAppService.Insert(createCompany.Company);
            if (resultCompany.WasCreated) {
                var config = new Configuration() {
                 CompanyId = resultCompany.Id,
                 MainColor = ColorStyle.Default.ToString(),
                 SecondaryColor = ColorStyle.Secondary.ToString(),
                };
                
                var resultConfig = await _configurationAppService.Insert(config);
                await _componentTypeAppService.InsertMultipleComponentType();
                if (resultConfig.WasCreated) {
                    await _configComponentTypeAppService.CreateConfigComponentTypeInit(resultConfig.Id);
                }
                if (createCompany.File != null) {
                    createCompany.File.CompanyId = resultCompany.Id;
                    await _fileAppService.Insert(createCompany.File);
                }
            }
            var response = new ResponseModel()
            {
                Status = resultCompany.WasCreated,
                Message = resultCompany.WasCreated ? "Se registro exito" : "Error en creacion"       
            };
            return Json(response);
        }

		[HttpPut]
		public async Task<IActionResult> Update(Company company)
		{
			if (company == null)
				return BadRequest();

            var update = await _companyAppService.Update(company);
            var response = new ResponseModel()
            {
                Status = update,
                Message = update ? "Se actualizo exito" : "Error en actualizacion"
            };
            return Json( response);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(string id)
		{
			await _companyAppService.Delete(id);
			return NoContent();
		}
	}
}
