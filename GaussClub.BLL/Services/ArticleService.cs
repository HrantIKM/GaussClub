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
        private readonly ILabelService _labelService;

        public ArticleService(IUnitOfWork unitOfWork, ILabelService labelService)
        {
            _unitOfWork = unitOfWork;
            _labelService = labelService;
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
                Label = _labelService.GetById(labelId),
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
        public List<Article>? GetActiveArticles()
        {
            return _unitOfWork.ArticleRepository.GetSome(a => a.IsActive);
        }

        public Article? GetById(int? id)
        {
            return _unitOfWork.ArticleRepository.Get(a => a.Id == id);
        }
        public Article? GetBySlug(string slug)
        {
            return _unitOfWork.ArticleRepository.Get(a => a.Slug == slug && a.IsActive);
        }

        public ArticleVM GetArticleVM(Article? article)
        {
            var labels = new List<Label>();

            foreach (var label in article.ArticleLabels)
            {
                labels.Add(_labelService.GetById(label.LabelId));
            }

            return new ArticleVM
            {
                Article = article,
                ArticleLabels = labels
            };
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
