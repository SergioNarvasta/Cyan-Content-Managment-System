
using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Domain.Entities;
using CyanCMS.Utils.Constants;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyanCMS.WebPlatform.Controllers
{
	public class IdentityController : Controller
	{
		private readonly ISessionAppService _sessionAppService;
		public IdentityController(ISessionAppService sessionAppService) 
		{
		    _sessionAppService = sessionAppService;
		}

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.IsLoginView = true;
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Login(SessionDto request)
		{
			string keySession = Constant.key_CurrentSession;
			ResponseModel response = new();
            var user = await _sessionAppService.GetSession(request);

            if (user.UserId != 0)
            {
				response.Id = user.UserId;
				response.Message = "Inicio de Sesion Exitoso";
                response.Status = true;				
            }
            else
            {
                response.Message = "Inicio de sesion no valido, verifique credenciales!";
                response.Status = false;
            }
            return Json(response);
        }  
    }
}
