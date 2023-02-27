using _01_DigiDigoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {

        private readonly IProductQuery _productQuery;
        public List<ProductQueryModel> ProductModel { get; set; }
        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string value)
        {
            ViewData["searchcvalue"] = value;
            ProductModel = _productQuery.Search(value);
            
        }
    }
}
