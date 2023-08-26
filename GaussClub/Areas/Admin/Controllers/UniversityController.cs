using GaussClub.BLL.Contracts;
using GaussClub.BLL.Services;
using GaussClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UniversityController : Controller
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_universityService.GetAll());
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View(_universityService.GetAll());
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
                _universityService.Add(university);

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

            var university = _universityService.GetById(id);

            if (university is null)
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
                _universityService.Update(university);

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

            var university = _universityService.GetById(id);

            if (university == null)
            {
                return NotFound();
            }

            _universityService.Remove(university);

            TempData["success"] = "Համալսարանը հաջողությամբ ջնջված է";

            return RedirectToAction("Manage");
        }
    }
}
