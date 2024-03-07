using CLIENT_MVC.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CLIENT_MVC.Controllers
{
    public class LoginController : Controller
    {
        const string ACCESS_CONTROLLER = "Auth";
        private readonly APIHelper _apiHelper;
        public LoginController(APIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
