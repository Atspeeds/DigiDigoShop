using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastrure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }


        public EditArticle Details(long id)
        {

            var article = _blogContext.Articles.Select(x => new EditArticle()
            {
                Id = x.KeyId,
                ShortDescription = x.ShortDescription,
                DateRelease = x.DateRelease,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Author = x.Author,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                KeyWords = x.KeyWords,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Title = x.Title,
            }).FirstOrDefault(a => a.Id == id);


            return article;
        }


        public List<ArticleViewModel> Search(SearchArticle searchModel)
        {
            var articleCategories = _blogContext.ArticleCategories
                .Select(x => new { x.KeyId, x.Name }).ToList();


            var query = _blogContext.Articles
                .Select(x => new ArticleViewModel()
                {
                    Id = x.KeyId,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    Author = x.Author,
                    DateRelease = x.DateRelease.ToFarsi(),
                    Picture = x.Picture,
                    CreationDate = x.CreationDate.ToFarsi(),
                });


            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));


            if (!string.IsNullOrWhiteSpace(searchModel.DateRelease))
                query = query.Where(x => x.DateRelease == searchModel.DateRelease);

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);


            var articles = query.AsNoTracking().OrderByDescending(x => x.Id).ToList();

            articles.ForEach(a => a.Category = articleCategories.FirstOrDefault(x => x.KeyId == a.CategoryId).Name);


            return articles;

        }
    }
}
