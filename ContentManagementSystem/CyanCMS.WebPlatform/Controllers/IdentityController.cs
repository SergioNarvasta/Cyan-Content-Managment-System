using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Utils.Constants;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Mvc;

namespace CyanCMS.WebPlatform.Controllers
{
	public class IdentityController(ISessionAppService sessionAppService) : Controller
	{
		private readonly ISessionAppService _sessionAppService = sessionAppService;
        public string keySession = Constant.key_CurrentSession;

        [HttpGet]
        public IActionResult Login()
        {
            string UserIdSession = _sessionAppService.GetUserSession(keySession);
            if (!string.IsNullOrEmpty(UserIdSession))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.IsLoginView = true;
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Login(SessionDto request)
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
            return Json(response);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _sessionAppService.RemoveUserSession(keySession);

            return RedirectToAction("Login", "Identity");
        }
    }
}
