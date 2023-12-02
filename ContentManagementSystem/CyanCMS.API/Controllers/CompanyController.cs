

using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CyanCMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService) 
        {
			_companyAppService = companyAppService;
        }

        [Route("GetAllCompany")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            return Ok(await _companyAppService.GetAll());
        }

        [Route("GetCompanyById")]
        [HttpPost]
        public async Task<IActionResult> GetCompanyById(string User_Pk)
        {
            return Ok(await _companyAppService.GetById(User_Pk));
        }

        [Route("CreateCompany")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            if (company == null)
                return BadRequest();

			company.Company_Estado = 1;
			company.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            company.Company_Pk = Guid.NewGuid().ToString();

            await _companyAppService.Insert(company);
            return Created("Created", true);
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
