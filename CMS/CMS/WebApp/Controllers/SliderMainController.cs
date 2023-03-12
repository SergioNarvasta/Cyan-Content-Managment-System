
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

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

        [Route("lista")]
        [HttpGet]
        public async Task<IActionResult> GetAllSliderMain()
        {
            return Ok(await _sSliderMainAppService.GetAllSliderMain());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> CreateSliderMain([FromBody] SliderMain sliderMain)
        {
            if (sliderMain == null)
                return BadRequest();

            sliderMain.SliderMain_Estado = 1;
            sliderMain.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            sliderMain.SliderMain_Pk = Guid.NewGuid().ToString();

            await _sSliderMainAppService.InsertSliderMain(sliderMain);
            return Created("Created", true);
        }
    }
}
