using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
