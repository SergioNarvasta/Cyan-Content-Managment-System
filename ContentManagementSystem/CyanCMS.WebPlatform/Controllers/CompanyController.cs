﻿
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Common;
using CyanCMS.Utils.Constants;
using CyanCMS.Utils.Request;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using static CyanCMS.Utils.Common.Enums;
using static CyanCMS.Utils.Request.RequestModels;

namespace CyanCMS.WebPlatform.Controllers
{
    public class CompanyController(ICompanyAppService companyAppService,
        IConfigurationAppService configurationAppService,
        IComponentTypeAppService componentTypeAppService,
        IConfigurationComponentTypeAppService configurationComponentTypeAppService,
        IFileAppService fileAppService,
        ISessionAppService sessionAppService) : Controller
    {
        private readonly ICompanyAppService _companyAppService = companyAppService;
        private readonly IConfigurationAppService _configurationAppService = configurationAppService;
        private readonly IComponentTypeAppService _componentTypeAppService = componentTypeAppService;
        private readonly IConfigurationComponentTypeAppService _configComponentTypeAppService = configurationComponentTypeAppService;
        private readonly IFileAppService _fileAppService = fileAppService;
        private readonly ISessionAppService _sessionAppService = sessionAppService;

        public string keySession = Constant.key_CurrentSession;
        

        [HttpGet]
        public async Task<IActionResult> Index(RequestParams @params)
        {
            string companyNameFilter = string.Empty;
            string companyIsActiveFilter = string.Empty;
            var queryParams = new CompanyParams();

            if (@params.Filters is not null) {
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

            GenericDto<CompanyDto> data = await _companyAppService.GetAll(queryParams);

            DataPaginationRp dataPaginationRp = new DataPaginationRp<CompanyDto>() {
                PageNumber = @params.PageNumber,
                PageSize   = @params.PageSize,
                TotalCount = data.TotalCount,
                Elements   = data.Elements,
                BaseURL    = Url.Action(),
            };

            return View(dataPaginationRp);
        }

        [HttpPost]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return Json(await _companyAppService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetCompaniesByUser()
        {
            string userIdSession = _sessionAppService.GetUserSession(keySession);
            var companies = new List<CompanyDto>();
            if (!string.IsNullOrEmpty(userIdSession))
            {
                string keyCompaniesByUserSession = $"{Constant.key_CompaniesByUserSession}{userIdSession}";
                var companiesCache =  _companyAppService.GetCompaniesByUserSession_Cache(keyCompaniesByUserSession);
                if (companiesCache.Count == 0)
                {
                    companies = await _companyAppService.GetByUserId(int.Parse(userIdSession));
                }
                else
                {
                    companies = companiesCache;
                }              
            }
            return Json(new {companies, count = companies.Count} );
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyModel createCompany)
        {
            if (createCompany.Company == null)
                return BadRequest();

            var resultCompany = await _companyAppService.Insert(createCompany.Company);
            if (resultCompany.Status) {
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
                Status = resultCompany.Status,
                Message = resultCompany.Status ? "Se registro con exito" : "Error en creacion"       
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
		public async Task<IActionResult> Delete(int id)
		{
			await _companyAppService.Delete(id);
			return NoContent();
		}
	}
}
