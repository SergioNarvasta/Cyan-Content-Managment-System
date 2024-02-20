
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Constants;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.WebHost.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase
	{
		private readonly ISessionAppService _sessionAppService;
        public string keySession = Constant.key_CurrentSession;
        public SessionController(ISessionAppService sessionAppService) 
		{
		    _sessionAppService = sessionAppService;
		}


		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] SessionDto request)
		{
            ResponseModel response = new();
            var user = await _sessionAppService.GetSession(request);

            if (user.Id != 0)
            {
                response.Id = user.Id;
                response.Message = "Inicio de Sesion Exitoso";
                response.Status = true;

                _sessionAppService.SetUserSession(keySession, user.Id.ToString());
            }
            else
            {
                response.Message = "Inicio de sesion no valido, verifique credenciales!";
                response.Status = false;
            }
            return Ok(response);
        }
	}
}
