﻿using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
