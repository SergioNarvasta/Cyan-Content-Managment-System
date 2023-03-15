
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

        public SliderMainController(ISliderMainAppService contentMainAppService ) 
        {
            _sSliderMainAppService = contentMainAppService;
        }

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sSliderMainAppService.GetAllSliderMain());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SliderMain sliderMain)
        {
            if (sliderMain == null)
                return BadRequest();
			
			sliderMain.SliderMain_Estado = 1;
            sliderMain.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            sliderMain.SliderMain_Pk = Guid.NewGuid().ToString();

            await _sSliderMainAppService.InsertSliderMain(sliderMain);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] SliderMain sliderMain, string id)
		{
			if (sliderMain == null)
				return BadRequest();

			sliderMain.SliderMain_Id = new MongoDB.Bson.ObjectId(id);
            await _sSliderMainAppService.UpdateSliderMain(sliderMain);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _sSliderMainAppService.DeleteSliderMain(id);
			return NoContent();
		}
	}
}
