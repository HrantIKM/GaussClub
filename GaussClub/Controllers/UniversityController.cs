using GaussClub.DAL.Data;
using GaussClub.Models;
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

        public IActionResult Manage()
        {
            var universities = _context.Universities.ToList();

            return View(universities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(University university)
        {
            if (ModelState.IsValid)
            {
                _context.Universities.Add(university);
                _context.SaveChanges();

                TempData["success"] = "Համալսարանը հաջողությամբ գրանցված է";
                
                return RedirectToAction("Manage");
            }

            TempData["error"] = "Համալսարանը չի գրանցվել";

            return View(university);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var university = _context.Universities.Find(id);

            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        [HttpPost]
        public IActionResult Edit(University university)
        {
            if (ModelState.IsValid)
            {
                _context.Universities.Update(university);
                _context.SaveChanges();

                TempData["success"] = "Համալսարանը հաջողությամբ պահպանված է";

                return RedirectToAction("Manage");
            }

            TempData["error"] = "Համալսարանը չի փոփոխվել";

            return View(university);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var university = _context.Universities.Find(id);

            if (university == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(university);
            _context.SaveChanges();

            TempData["success"] = "Համալսարանը հաջողությամբ ջնջված է";

            return RedirectToAction("Manage");
        }
    }
}
