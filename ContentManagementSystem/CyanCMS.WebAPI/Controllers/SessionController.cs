using CMS.Aplicacion.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase
	{
		private readonly ISessionService _sessionAppService;
		public SessionController(ISessionService sessionAppService) 
		{
		    _sessionAppService = sessionAppService;
		}


		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] SessionDto request)
		{
			User usuario = new User();
			try
			{
				usuario = await _sessionAppService.Session(request);

                if (usuario == null)
					usuario = new User();

				return StatusCode(StatusCodes.Status200OK, usuario);
			}
			catch
			{
				return StatusCode(StatusCodes.Status500InternalServerError, usuario);
			}
		}
	}
}
