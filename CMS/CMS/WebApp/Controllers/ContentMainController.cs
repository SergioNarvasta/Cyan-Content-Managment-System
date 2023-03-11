
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentMainController : ControllerBase
    {
        private readonly IContentMainAppService _sContentMainAppService; //= new ContentMainAppService();

        public ContentMainController(IContentMainAppService contentMainAppService ) 
        {
            _sContentMainAppService = contentMainAppService;
        }

        [Route("lista")]
        [HttpGet]
        public async Task<IActionResult> GetAllContentMain()
        {
            return Ok(await _sContentMainAppService.GetAllContentMain());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> CreateContentMain([FromBody] ContentMain contentmain)
        {
            if (contentmain == null)
                return BadRequest();

            if (contentmain.ContentMain_Titulo == string.Empty)
            {
                ModelState.AddModelError("Titulo", "El Titulo de contenido no debe ser vacio");
            }
            contentmain.ContentMain_Estado = 1;
            contentmain.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            contentmain.ContentMain_Pk = Guid.NewGuid().ToString();

            await _sContentMainAppService.InsertContentMain(contentmain);
            return Created("Created", true);
        }


    }
}
