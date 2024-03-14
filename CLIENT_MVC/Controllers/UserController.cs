using CLIENT_MVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using PROJECT_PRN231.Models;
using PROJECT_PRN231.Models.Account;
using System.Net;

namespace CLIENT_MVC.Controllers
{
    public class UserController : Controller
    {
        const string CONTROLLER_USER = "User/";
        private readonly APIHelper _apiHelper;
        public UserController(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");
            var user = await _apiHelper.RequestGetAsync<User>(CONTROLLER_USER + $"Detail{username}");
            return View(user);
        }

        public IActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(ChangePassword model)
        {
            var result = await _apiHelper.RequestPutAsync<ChangePassword>(CONTROLLER_USER + "ChangePassword", model);
            if (result.Response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (result.Response.StatusCode == HttpStatusCode.BadRequest)
            {
                ViewBag.Validate = result.Body;
            }
            return View(model);
        }
    }
}
