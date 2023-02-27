using _01_DigiDigoQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.Linq;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productcategoryModel = _productCategoryQuery.GetProductCategoriesMainPage();
            return View(productcategoryModel);
        }

    }
}
