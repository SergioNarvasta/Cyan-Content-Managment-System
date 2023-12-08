
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CyanCMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService ) 
        {
            _userAppService = userAppService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userAppService.GetAll());
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

			user.IsActive = true;
            user.IsDeleted = false;
            user.AuditCreateDate = DateTime.Now;

            await _userAppService.Insert(user);
            return Created("Created", true);
        }

		[Route("UpdateUser")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] User user)
		{
			if (user == null)
				return BadRequest();

			//user.User_Id = new MongoDB.Bson.ObjectId(id);
            await _userAppService.Update(user);
			return Created("Update", true);
		}

		[Route("Delete")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _userAppService.Delete(id);
			return NoContent();
		}
	}
}
