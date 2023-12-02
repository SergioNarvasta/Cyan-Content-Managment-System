
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CyanCMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsideController : ControllerBase
    {
        private readonly IAsideAppService _asideAppService;

        public AsideController(IAsideAppService asideAppService) 
        {
            _asideAppService = asideAppService;
        }

        [Route("GetAllAside")]
        [HttpGet]
        public async Task<IActionResult> GetAllAside()
        {
            return Ok(await _asideAppService.GetAll());
        }

        [Route("CreateAside")]
        [HttpPost]
        public async Task<IActionResult> CreateAside([FromBody] Aside model)
        {
            if (model == null)
                return BadRequest();

            model.Aside_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.Aside_Pk = Guid.NewGuid().ToString();

            await _asideAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("UpdateAside")]
		[HttpPut]
		public async Task<IActionResult> UpdateAside([FromBody] Aside model, string id)
		{
			if (model == null)
				return BadRequest();

			model.Aside_Id = new MongoDB.Bson.ObjectId(id);
            await _asideAppService.Update(model);
			return Created("Update", true);
		}

		[Route("DeleteAside")]
		[HttpDelete]
		public async Task<IActionResult> DeleteAside([FromBody] string id)
		{
			await _asideAppService.Delete(id);
			return NoContent();
		}
	}
}
