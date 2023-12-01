
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentMainController : ControllerBase
    {
        private readonly IContentMainAppService _contentMainAppService;

        public ContentMainController(IContentMainAppService contentMainAppService ) 
        {
            _contentMainAppService = contentMainAppService;
        }

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contentMainAppService.GetAll());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContentMain model)
        {
            if (model == null)
                return BadRequest();

            model.ContentMain_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.ContentMain_Pk = Guid.NewGuid().ToString();

            await _contentMainAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] ContentMain model, string id)
		{
			if (model == null)
				return BadRequest();

			model.ContentMain_Id = new MongoDB.Bson.ObjectId(id);
            await _contentMainAppService.Update(model);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _contentMainAppService.Delete(id);
			return NoContent();
		}
	}
}
