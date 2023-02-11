using _01_DigiDigoQuery.Contract.Product;
using _01_DigiDigoQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var model = _productCategoryQuery.GetProductCategoriesWithProducts();
            return View(model);
        }


    }
}
