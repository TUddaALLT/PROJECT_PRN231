﻿using Microsoft.AspNetCore.Mvc;

namespace PROJECT_PRN231.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
