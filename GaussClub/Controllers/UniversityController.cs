using GaussClub.DAL.Contracts;
using GaussClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UniversityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var universities = _unitOfWork.UniversityRepository.GetAll().ToList();

            return View(universities);
        }

        public IActionResult Manage()
        {
            var universities = _unitOfWork.UniversityRepository.GetAll().ToList();

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
                _unitOfWork.UniversityRepository.Add(university);
                _unitOfWork.Save();

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

            var university = _unitOfWork.UniversityRepository.Get(u => u.Id == id);

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
                _unitOfWork.UniversityRepository.Update(university);
                _unitOfWork.Save();

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

            var university = _unitOfWork.UniversityRepository.Get(u => u.Id == id);

            if (university == null)
            {
                return NotFound();
            }

            _unitOfWork.UniversityRepository.Remove(university);
            _unitOfWork.Save();

            TempData["success"] = "Համալսարանը հաջողությամբ ջնջված է";

            return RedirectToAction("Manage");
        }
    }
}
