using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;

        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }


        public SearchProductPicture searchModel;
        public IEnumerable<ProductPictureViewModel> ProductPictures { get; set; }



        public void OnGet(SearchProductPicture searchmodel)
        {
            ProductPictures = _productPictureApplication.Search(searchmodel);
        }

        public IActionResult OnGetCreate()
        {
            var Product = new CreateProductPicture()
            {
                products = _productApplication.GetSelectList()
            };
            return Partial("./Create", Product);
        }

    }
}
