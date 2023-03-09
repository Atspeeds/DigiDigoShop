using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastrure.EfCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }


        public EditArticleCategory Details(long id)
        {
            var details = _blogContext.ArticleCategories
                .Select(x => new EditArticleCategory()
                {
                    Id = id,
                    Name = x.Name,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    ShortDescription = x.ShortDescription,
                    CanonicalAddress = x.CanonicalAddress,
                    KeyWords = x.KeyWords,
                    Slug = x.Slug,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShowOrder = x.ShowOrder,
                })
                .FirstOrDefault(x => x.Id == id);
            return details;
        }

        public string GetSlug(long id)
        {
            return _blogContext.ArticleCategories
                .Select(x => new { x.KeyId, x.Slug })
                .FirstOrDefault(c => c.KeyId == id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(SearchArticleCategory searchModel)
        {
            var query = _blogContext.ArticleCategories
                .Select(x => new ArticleCategoryViewModel()
                {
                    Id = x.KeyId,
                    Name = x.Name,
                    shortDescription = x.ShortDescription,
                    Picture = x.Picture,
                    ShowOrder = x.ShowOrder,
                    CreationDate = x.CreationDate.ToFarsi(),
                });

            if (!string.IsNullOrEmpty(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));


            return query.OrderByDescending(x => x.ShowOrder).ToList();

        }

        public List<ArticleCategoryViewModel> SelectList()
        {
            return _blogContext.ArticleCategories
                .Select(x => new ArticleCategoryViewModel()
                {
                    Id = x.KeyId,
                    Name = x.Name
                }).ToList();
        }
    }
}
