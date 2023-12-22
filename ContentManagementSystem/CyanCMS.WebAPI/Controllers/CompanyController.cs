﻿

using Cyan.Utils.Common;
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Common;
using CyanCMS.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using static CyanCMS.Utils.Common.Enums;
using static CyanCMS.Utils.Request.RequestModels;

namespace CyanCMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
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

        [Route("GetAllCompany")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompany([FromBody] RequestParams? @params)
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

            return Ok(await _companyAppService.GetAll(queryParams));
        }

        [Route("GetCompanyById")]
        [HttpPost]
        public async Task<IActionResult> GetCompanyById(string User_Pk)
        {
            return Ok(await _companyAppService.GetById(User_Pk));
        }

        [Route("CreateCompany")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyModel createCompany)
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
            return Created("Created", response);
        }

		[Route("UpdateCompany")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Company company)
		{
			if (company == null)
				return BadRequest();

			//company.Company_Id = new MongoDB.Bson.ObjectId(id);
            await _companyAppService.Update(company);
			return Created("Update", true);
		}

		[Route("DeleteCompany")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _companyAppService.Delete(id);
			return NoContent();
		}
	}
}
