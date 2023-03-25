
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
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

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _companyAppService.GetAllCompany());
        }

        [Route("listbyid")]
        [HttpGet]
        public async Task<IActionResult> GetById(string User_Pk)
        {
            return Ok(await _companyAppService.GetCompanyById(User_Pk));
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Company company)
        {
            if (company == null)
                return BadRequest();

			company.Company_Estado = 1;
			company.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            company.Company_Pk = Guid.NewGuid().ToString();

            await _companyAppService.InsertCompany(company);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] Company company, string id)
		{
			if (company == null)
				return BadRequest();

			company.Company_Id = new MongoDB.Bson.ObjectId(id);
            await _companyAppService.UpdateCompany(company);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _companyAppService.DeleteCompany(id);
			return NoContent();
		}
	}
}
