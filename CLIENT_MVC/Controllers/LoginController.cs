using CLIENT_MVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using PROJECT_PRN231.Models;
using System.Net;

namespace CLIENT_MVC.Controllers
{
    public class LoginController : Controller
    {
        const string ACCESS_CONTROLLER = "Auth/";
        private readonly APIHelper _apiHelper;
        public LoginController(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Validate = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiHelper.RequestPostAsync<Login>(ACCESS_CONTROLLER + "Login", login);
                if (result.Response.IsSuccessStatusCode)
                {
                    var loginResult = JsonConvert.DeserializeObject<LoginResult>(result.Body);
                    _apiHelper.BearerToken = loginResult.Token;
                    return RedirectToAction("Index", "Home");
                }
                else if (result.Response.StatusCode == HttpStatusCode.BadRequest) 
                {
                    ViewBag.Validate = result.Body;
                }
                return View(login);
            }
            else
            {
                return View(login);
            }
        }
    }
}
