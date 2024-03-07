using CLIENT_MVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT_PRN231.Models;

namespace CLIENT_MVC.Controllers
{
    public class RegisterController : Controller
    {
        const string ACCESS_CONTROLLER = "Auth/";
        private readonly APIHelper _apiHelper;
        public RegisterController(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var result = await _apiHelper.RequestPostAsync<Register>("Register", register);
                Console.WriteLine(result);
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }
    }
}
