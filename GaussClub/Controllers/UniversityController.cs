using GaussClub.Data;
using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class UniversityController : Controller
    {
        private readonly AppDbContext _context;

        public UniversityController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var universities = _context.Universities.ToList();
            return View(universities);
        }
    }
}
