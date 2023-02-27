using _01_DigiDigoQuery.Contract.Product;
using _01_DigiDigoQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ServiceHost.Pages
{
    public class ProductDetailsModel : PageModel
    {

        private readonly IProductQuery _productQuery;



        public ProductDetailsModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public ProductQueryModel ProductModel;


        public void OnGet(string id)
        {
            ProductModel = _productQuery.GetDetails(id);

            ProductModel.ProductQueryModels = _productQuery.GetRelatedProductsBy(new ProductRelatedQueryModel(
                                            ProductModel.CategorySlug, ProductModel.ProductId));

        }
    }
}
