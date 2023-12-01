
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerAppService _partnerAppService;

        public PartnerController(IPartnerAppService partnerAppService) 
        {
			_partnerAppService = partnerAppService;
        }

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _partnerAppService.GetAll());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Partner model)
        {
            if (model == null)
                return BadRequest();

            model.Partner_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.Partner_Pk = Guid.NewGuid().ToString();

            await _partnerAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] Partner model, string id)
		{
			if (model == null)
				return BadRequest();

			model.Partner_Id = new MongoDB.Bson.ObjectId(id);
            await _partnerAppService.Update(model);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _partnerAppService.Delete(id);
			return NoContent();
		}
	}
}
