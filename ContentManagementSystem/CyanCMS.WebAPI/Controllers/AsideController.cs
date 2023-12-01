
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

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _asideAppService.GetAll());
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Aside model)
        {
            if (model == null)
                return BadRequest();

            model.Aside_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.Aside_Pk = Guid.NewGuid().ToString();

            await _asideAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("Update")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] Aside model, string id)
		{
			if (model == null)
				return BadRequest();

			model.Aside_Id = new MongoDB.Bson.ObjectId(id);
            await _asideAppService.Update(model);
			return Created("Update", true);
		}

		[Route("Delete")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _asideAppService.Delete(id);
			return NoContent();
		}
	}
}
