using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
