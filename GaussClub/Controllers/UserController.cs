﻿using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}