using _0_FrameWork.Domain;
using BlogManagement.Application.Contract.Article;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository: IRepositoryBase<long,Article>
    {
        List<ArticleViewModel> Search(SearchArticle searchModel);
        EditArticle Details(long id);
    }
}
