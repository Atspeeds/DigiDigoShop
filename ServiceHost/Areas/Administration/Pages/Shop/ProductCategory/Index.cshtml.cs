using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public SearchProductCategory searchModel;

        public IEnumerable<ProductCategoryViewModel> ProductCategories;

        public void OnGet(SearchProductCategory searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var resualt = _productCategoryApplication.Add(command);
            return new JsonResult(resualt);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _productCategoryApplication.GetDetails(id);
            return Partial("./Edit", productcategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var resualt = _productCategoryApplication.Edit(command);
            return new JsonResult(resualt);
        }
    }
}