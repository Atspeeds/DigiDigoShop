using _0_FrameWork.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OprationResualt Add(CreateArticleCategory command);
        OprationResualt Edit(EditArticleCategory command);
        List<ArticleCategoryViewModel> Search(SearchArticleCategory searchModel);
        EditArticleCategory GetDetails(long id);
       List<ArticleCategoryViewModel> SelectItemArticleCategory();
    }
}
