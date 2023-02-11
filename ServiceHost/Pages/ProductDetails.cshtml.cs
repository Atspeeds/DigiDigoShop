using _01_DigiDigoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public ProductQueryModel ProductModel;
        public ProductDetailsModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            ProductModel = _productQuery.GetDetails(id);
        }
    }
}
