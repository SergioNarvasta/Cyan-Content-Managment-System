
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleComponentController : ControllerBase
    {
        private readonly ITitleComponentService _titleComponentService;

        public TitleComponentController(ITitleComponentService titleComponentService) 
        {
			_titleComponentService = titleComponentService;
        }

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _titleComponentService.GetAll());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TitleComponent model)
        {
            if (model == null)
                return BadRequest();

            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.TitleComponent_Pk = Guid.NewGuid().ToString();

            await _titleComponentService.Insert(model);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] TitleComponent model, string id)
		{
			if (model == null)
				return BadRequest();

			model.TitleComponent_Id = new MongoDB.Bson.ObjectId(id);
            await _titleComponentService.Update(model);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _titleComponentService.Delete(id);
			return NoContent();
		}
	}
}
