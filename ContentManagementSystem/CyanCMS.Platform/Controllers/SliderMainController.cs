
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderMainController : ControllerBase
    {
        private readonly ISliderMainAppService _sSliderMainAppService;

        public SliderMainController(ISliderMainAppService sliderMainAppService) 
        {
            _sSliderMainAppService = sliderMainAppService;
        }

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sSliderMainAppService.GetAll());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SliderMain model)
        {
            if (model == null)
                return BadRequest();
			
			model.SliderMain_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.SliderMain_Pk = Guid.NewGuid().ToString();

            await _sSliderMainAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] SliderMain model, string id)
		{
			if (model == null)
				return BadRequest();

            model.SliderMain_Id = new MongoDB.Bson.ObjectId(id);
            await _sSliderMainAppService.Update(model);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _sSliderMainAppService.Delete(id);
			return NoContent();
		}
	}
}
