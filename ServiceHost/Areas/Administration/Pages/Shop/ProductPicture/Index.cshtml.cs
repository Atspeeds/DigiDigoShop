using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IProductPictureApplication _productPictureApplication;

        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }


        public SearchProductPicture searchModel;

        public IEnumerable<ProductPictureViewModel> ProductPictures;

        public SelectList ListItemsProduct;


        public void OnGet(SearchProductPicture searchmodel)
        {
            ListItemsProduct = new SelectList(_productApplication.GetSelectList(), "Id", "Name");

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


        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var resualt = _productPictureApplication.Add(command);
            return new JsonResult(resualt);
        }


        public IActionResult OnGetEdit(long id)
        {
            var productpicture = _productPictureApplication.GetDetails(id);

            productpicture.products = _productApplication.GetSelectList();

            return Partial("./Edit", productpicture);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var resualt = _productPictureApplication.Edit(command);

            return new JsonResult(resualt);
        } 

        public IActionResult OnGetRemove(long id)
        {
            var resualt=_productPictureApplication.Deleted(id);

            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var resualt = _productPictureApplication.Restore(id);
            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");
        }

    }
}
