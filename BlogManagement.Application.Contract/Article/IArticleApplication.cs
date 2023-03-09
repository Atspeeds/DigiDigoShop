using _0_FrameWork.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contract.Article
{
    public interface IArticleApplication
    {
        OprationResualt Add(CreateArticle command);
        OprationResualt Edit(EditArticle command);
        List<ArticleViewModel> Search(SearchArticle searchModel);
        EditArticle GetDetails(long id);
    }
}
