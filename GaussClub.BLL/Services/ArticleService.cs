using GaussClub.BLL.Contracts;
using GaussClub.BLL.Helpers;
using GaussClub.DAL.Contracts;
using GaussClub.Models;
using GaussClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GaussClub.BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private Article SetupCreateData(ArticleVM viewModel)
        {
            viewModel.Article.Slug?.Trim();
            viewModel.Article.CreatedAt = DateTime.Now;
            viewModel.Article.UpdatedAt = DateTime.Now;
            viewModel.Article.ArticleLabels = viewModel.LabelIds?.Select(labelId => new ArticleLabel
            {
                LabelId = labelId
            }).ToList();

            return viewModel.Article;
        }

        private Article SetupUpdateData(ArticleVM viewModel, Article? entity)
        {
            entity.Title = viewModel.Article.Title;
            entity.Slug = viewModel.Article.Slug?.Trim();
            entity.Content = viewModel.Article.Content;
            entity.Author = viewModel.Article.Author?.Trim();
            entity.IsActive = viewModel.Article.IsActive;
            entity.UpdatedAt = DateTime.Now;
            entity.ImageUrl = viewModel.Article.ImageUrl;
            entity.ArticleLabels?.Clear();
            entity.ArticleLabels = viewModel.LabelIds?.Select(labelId => new ArticleLabel
            {
                LabelId = labelId
            }).ToList();
            return entity;
        }

        public ArticleVM? SetupViewData(Article? article)
        {
            return new ArticleVM()
            {
                Article = article is null ? new Article() : article,
                LabelIds = article is null ? new List<int>() : article.ArticleLabels?.Select(al => al.LabelId).ToList(),
            };
        }

        public List<Article> GetAll()
        {
            return _unitOfWork.ArticleRepository.GetAll().ToList();
        }

        public Article? GetById(int? id)
        {
            return _unitOfWork.ArticleRepository.Get(a => a.Id == id);
        }

        public void Add(ArticleVM articleVM, string rootPath, IFormFile? file)
        {
            if (_unitOfWork.ArticleRepository.Any(a => a.Slug == articleVM.Article.Slug))
            {
                throw new Exception("Slug dublicate error.");
            }

            articleVM.Article.ImageUrl = ImageHelper.SaveImage(rootPath, @"uploads\Article\", file);

            _unitOfWork.ArticleRepository.Add(SetupCreateData(articleVM));

            _unitOfWork.Save();
        }

        public void Update(ArticleVM articleVM, string rootPath, IFormFile? file)
        {
            var entity = _unitOfWork.ArticleRepository.Get(a => a.Id == articleVM.Article.Id);

            if (_unitOfWork.ArticleRepository.Any(a => a.Slug == articleVM.Article.Slug && a.Id != entity.Id))
            {
                throw new Exception("Slug dublicate error.");
            }

            articleVM.Article.ImageUrl = ImageHelper.SaveImage(rootPath, @"uploads\Article\", file, entity?.ImageUrl);

            _unitOfWork.ArticleRepository.Update(SetupUpdateData(articleVM, entity));

            _unitOfWork.Save();
        }
        public void Remove(Article article, string rootPath)
        {
            ImageHelper.DeleteImage(rootPath, article.ImageUrl);

            _unitOfWork.ArticleRepository.Remove(article);
            _unitOfWork.Save();
        }
    }
}
