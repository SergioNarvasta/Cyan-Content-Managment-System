
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CyanCMS.Domain.Entities;
using CyanCMS.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CyanCMS.WebAPI.Controllers
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

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _titleComponentService.GetAll());
        }

        [Route("Create")]
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

		[Route("UpdateTitleComponent")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] TitleComponent model, string id)
		{
			if (model == null)
				return BadRequest();

			model.TitleComponent_Id = new MongoDB.Bson.ObjectId(id);
            await _titleComponentService.Update(model);
			return Created("Update", true);
		}

		[Route("Delete")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _titleComponentService.Delete(id);
			return NoContent();
		}
	}
}
