using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
