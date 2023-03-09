using _0_FrameWork.Domain;
using BlogManagement.Application.Contract.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepositoryBase<long, ArticleCategory>
    { 
        EditArticleCategory Details(long id);
       List<ArticleCategoryViewModel> Search(SearchArticleCategory searchModel);
        string GetSlug(long id);
        List<ArticleCategoryViewModel> SelectList();
    }
}
