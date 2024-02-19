using CyanCMS.Application.Interfaces;
using CyanCMS.Utils.Constants;
using CyanCMS.WebPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CyanCMS.WebPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionAppService _sessionAppService;
        private readonly IUserAppService _userAppService;
        public HomeController(ILogger<HomeController> logger, ISessionAppService sessionAppService, IUserAppService userAppService)
        {
            _logger = logger;
            _sessionAppService = sessionAppService;
            _userAppService = userAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string keySession = Constant.key_CurrentSession;
            string UserIdSession = _sessionAppService.GetUserSession(keySession);
            if (!string.IsNullOrEmpty(UserIdSession))
            {
                var user = await _userAppService.GetById(int.Parse(UserIdSession));
                ViewBag.UserEmail = user.Email;
                ViewBag.UserName = user.Name;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
