using _01_DigiDigoQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryQueryModel ProductCategory;

        public ProductCategoryModel(IProductCategoryQuery productCategoryquery)
        {
            _productCategoryQuery = productCategoryquery;
        }

        public void OnGet(string id)
        {
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProducstsBy(id);
        }
    }
}
