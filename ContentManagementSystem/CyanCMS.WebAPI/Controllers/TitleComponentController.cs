
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using CyanCMS.Application.Interfaces;
using CyanCMS.Application.Services;
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
        private readonly ITitleComponentAppService _titleComponentAppService;

        public TitleComponentController(ITitleComponentAppService titleComponentAppService) 
        {
			_titleComponentAppService = titleComponentAppService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _titleComponentAppService.GetAll());
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TitleComponent model)
        {
            if (model == null)
                return BadRequest();

            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.TitleComponent_Pk = Guid.NewGuid().ToString();

            await _titleComponentAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("UpdateTitleComponent")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] TitleComponent model, string id)
		{
			if (model == null)
				return BadRequest();

			model.TitleComponent_Id = new MongoDB.Bson.ObjectId(id);
            await _titleComponentAppService.Update(model);
			return Created("Update", true);
		}

		[Route("Delete")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _titleComponentAppService.Delete(id);
			return NoContent();
		}
	}
}
