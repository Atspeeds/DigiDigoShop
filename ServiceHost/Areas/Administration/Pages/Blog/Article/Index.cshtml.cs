using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {


        public IArticleApplication _articleApplication;

        public IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        [TempData]
        public string Message { get; set; }

       public SelectList listItems;

        public SearchArticle searchModel;

        public IEnumerable<ArticleViewModel> Articles;


        public void OnGet(SearchArticle searchModel)
        {
            listItems = new SelectList(
                _articleCategoryApplication.SelectItemArticleCategory(),"Id", "Name");
            Articles = _articleApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var category = new CreateArticle()
            {
                Categories = _articleCategoryApplication.SelectItemArticleCategory()
            };
            return Partial("./Create",category);
        }

        public JsonResult OnPostCreate(CreateArticle command)
        {
            var resualt = _articleApplication.Add(command);
            return new JsonResult(resualt);
        }

        public IActionResult OnGetEdit(long id)
        {
            var articleModel = _articleApplication.GetDetails(id);
            return Partial("./Edit", articleModel);
        }


        public JsonResult OnPostEdit(EditArticle command)
        {
            var resualt = _articleApplication.Edit(command);
            return new JsonResult(resualt);
        }

    }
}