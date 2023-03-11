
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentMainController : ControllerBase
    {
        private readonly IContentMainAppService _serviceContentMainAppService;  //= new ProjectCollection();

        public ContentMainController(IContentMainAppService contentMainAppService ) 
        {
            _serviceContentMainAppService = contentMainAppService;
        }

        [Route("lista")]
        [HttpGet]
        public async Task<IActionResult> GetAllContentMain()
        {
            return Ok(await _serviceContentMainAppService.GetAllContentMain());
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

            await _serviceContentMainAppService.InsertContentMain(contentmain);
            return Created("Created", true);
        }


    }
}
