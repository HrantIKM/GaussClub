using GaussClub.Models;
using GaussClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GaussClub.BLL.Contracts
{
    public interface IArticleService
    {
        ArticleVM? SetupViewData(Article? article);
        List<Article> GetAll();
        Article? GetById(int? id);
        void Add(ArticleVM articleVM, string rootPath, IFormFile? file);
        void Update(ArticleVM articleVM, string rootPath, IFormFile? file);
        void Remove(Article article, string rootPath);
    }
}
