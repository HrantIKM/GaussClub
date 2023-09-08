using GaussClub.BLL.Contracts;
using GaussClub.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GaussClub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ILabelService _labelService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public ArticleController(
            IArticleService articleService,
            ILabelService labelService,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _articleService = articleService;
            _labelService = labelService;
            _webHostEnviroment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_articleService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LabelList = _labelService.GetForSelect();
            return View(_articleService.SetupViewData(null));
        }

        [HttpPost]
        public IActionResult Create(ArticleVM articleVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _articleService.Add(articleVM, _webHostEnviroment.WebRootPath, file);

                TempData["success"] = "Հրապարակումը հաջողությամբ ստեղծված է";

                return RedirectToAction("Index");
            }

            TempData["error"] = "Հրապարակումը չի ստեղծվել";

            return View(articleVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var article = _articleService.GetById(id);

            if (article is null)
            {
                return NotFound();
            }

            ViewBag.LabelList = _labelService.GetForSelect();

            return View(_articleService.SetupViewData(article));
        }

        [HttpPost]
        public IActionResult Edit(ArticleVM articleVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _articleService.Update(articleVM, _webHostEnviroment.WebRootPath, file);

                TempData["success"] = "Հրապարակումը հաջողությամբ պահպանված է";

                return RedirectToAction("Index");
            }

            TempData["error"] = "Հրապարակումը չի փոփոխվել";

            return View(articleVM);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var article = _articleService.GetById(id);

            if (article == null)
            {
                return NotFound();
            }

            _articleService.Remove(article, _webHostEnviroment.WebRootPath);

            TempData["success"] = "Հրապարակումը հաջողությամբ ջնջված է";

            return RedirectToAction("Index");
        }
    }
}
