
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CyanCMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentSecController : ControllerBase
    {
        private readonly IContentSecAppService _contentSecAppService;

        public ContentSecController(IContentSecAppService contentSecAppService) 
        {
            _contentSecAppService = contentSecAppService;
        }

        [Route("GetAllContentSec")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contentSecAppService.GetAll());
        }

        [Route("CreateContentSec")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContentSec model)
        {
            if (model == null)
                return BadRequest();

            model.ContentSec_Estado = 1;
            model.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
            model.ContentSec_Pk = Guid.NewGuid().ToString();

            await _contentSecAppService.Insert(model);
            return Created("Created", true);
        }

		[Route("UpdateContentSec")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] ContentSec model, string id)
		{
			if (model == null)
				return BadRequest();

			model.ContentSec_Id = new MongoDB.Bson.ObjectId(id);
            await _contentSecAppService.Update(model);
			return Created("Update", true);
		}

		[Route("DeleteContentSec")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _contentSecAppService.Delete(id);
			return NoContent();
		}
	}
}
