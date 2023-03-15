
using CMS.Aplicacion.Interfaces;
using CMS.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebApp.Controllers
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

        [Route("listatodos")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userAppService.GetAllUser());
        }

        [Route("registro")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

			user.User_Estado = 1;
            user.Audit_FecCre = DateTime.Now.ToString("dd/MM/yyyy");
			user.User_Pk = Guid.NewGuid().ToString();

            await _userAppService.(user);
            return Created("Created", true);
        }

		[Route("actualiza")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] User user, string id)
		{
			if (user == null)
				return BadRequest();

			user.User_Id = new MongoDB.Bson.ObjectId(id);
            await _userAppService.UpdateUser(user);
			return Created("Update", true);
		}

		[Route("elimina")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromBody] string id)
		{
			await _userAppService.DeleteUser(id);
			return NoContent();
		}
	}
}
