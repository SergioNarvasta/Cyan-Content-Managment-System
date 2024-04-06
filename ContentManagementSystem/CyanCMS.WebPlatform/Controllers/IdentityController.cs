using CyanCMS.Application.Interfaces;
using CyanCMS.Domain.Dto;
using CyanCMS.Utils.Constants;
using CyanCMS.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using static CyanCMS.Utils.Common.Enums;

namespace CyanCMS.WebPlatform.Controllers
{
	public class IdentityController(ISessionAppService sessionAppService, ICompanyAppService companyAppService) : Controller
	{
		private readonly ISessionAppService _sessionAppService = sessionAppService;
        private readonly ICompanyAppService _companyAppService = companyAppService;
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
            
            ResponseLogin response = new ();
            var user = await _sessionAppService.GetSession(request);

            if (user is not null)
            {
                var companies = await _companyAppService.GetByUserId(user.Id);

                ResponseModel rp = new()
                {
                    Id = user.Id,
                    Message = ResponseMessage.LoginSucess,
                    Status = true,
                 };

                response.Response = rp;
                response.User = user;
                response.Companies = companies;
                
                _sessionAppService.SetUserSession(keySession, user.Id.ToString());
            }
            else
            {
                response.Response.Message = ResponseMessage.LoginError;
                response.Response.Status = false;
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
