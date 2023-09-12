using GaussClub.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GaussClub.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index(int? page = 1)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            var pageSize = 3;

            var articles = _articleService.GetActiveArticles()?
                .OrderByDescending(a => a.Id)
                .ToPagedList(page ?? 1, pageSize);

            return View(articles);
        }

        [Route("Article/{slug}")]
        public IActionResult Details(string slug)
        {
            var article = _articleService.GetArticleVM(_articleService.GetBySlug(slug));

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
    }
}
