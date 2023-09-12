using GaussClub.Models;
using GaussClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GaussClub.BLL.Contracts
{
    public interface IArticleService
    {
        ArticleVM? SetupViewData(Article? article);
        List<Article> GetAll();
        List<Article>? GetActiveArticles();
        Article? GetById(int? id);
        Article? GetBySlug(string slug);
        ArticleVM GetArticleVM(Article? article);
        void Add(ArticleVM articleVM, string rootPath, IFormFile? file);
        void Update(ArticleVM articleVM, string rootPath, IFormFile? file);
        void Remove(Article article, string rootPath);
    }
}
