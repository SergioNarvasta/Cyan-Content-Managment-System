
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderMainController : ControllerBase
    {
        private readonly ISliderMainAppService _sSliderMainAppService; //= new SliderMainAppService();

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
        public async Task<IActionResult> CreateSliderMain([FromBody] SliderMain contentmain)
        {
            if (contentmain == null)
                return BadRequest();

            if (contentmain.SliderMain_Titulo == string.Empty)
            {
                ModelState.AddModelError("Titulo", "El Titulo de contenido no debe ser vacio");
            }
            contentmain.SliderMain_Estado = 1;
            contentmain.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            contentmain.SliderMain_Pk = Guid.NewGuid().ToString();

            await _sSliderMainAppService.InsertSliderMain(contentmain);
            return Created("Created", true);
        }


    }
}
