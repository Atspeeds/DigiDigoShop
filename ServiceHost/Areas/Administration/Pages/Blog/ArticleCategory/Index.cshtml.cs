using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public SearchArticleCategory searchModel;

        public List<ArticleCategoryViewModel> ArticleCategories;

        public void OnGet(SearchArticleCategory searchModel)
        {
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var resualt = _articleCategoryApplication.Add(command);
            return new JsonResult(resualt);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _articleCategoryApplication.GetDetails(id);
            return Partial("./Edit", productcategory);
        }

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var resualt = _articleCategoryApplication.Edit(command);
            return new JsonResult(resualt);
        }
    }
}