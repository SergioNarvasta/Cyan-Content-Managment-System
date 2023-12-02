
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CyanCMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentMainController : ControllerBase
    {
        private readonly IContentMainAppService _contentMainAppService;

        public ContentMainController(IContentMainAppService contentMainAppService ) 
        {
            _contentMainAppService = contentMainAppService;
        }

        [Route("GetAllContentMain")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contentMainAppService.GetAll());
        }

        [Route("CreateContentMain")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContentMain model)
        {
            if (model == null)
                return BadRequest();

            model.ContentMain_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.ContentMain_Pk = Guid.NewGuid().ToString();

            await _contentMainAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("UpdateContentMain")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] ContentMain model, string id)
		{
			if (model == null)
				return BadRequest();

			model.ContentMain_Id = new MongoDB.Bson.ObjectId(id);
            await _contentMainAppService.Update(model);
			return Created("Update", true);
		}

		[Route("DeleteContentMain")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _contentMainAppService.Delete(id);
			return NoContent();
		}
	}
}
