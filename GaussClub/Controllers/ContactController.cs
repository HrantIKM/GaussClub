using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
