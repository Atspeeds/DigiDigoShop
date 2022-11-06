using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public IProductApplication _productApplication;

        public IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public SearchProduct searchModel;

        public IEnumerable<ProductViewModel> Products;

        public SelectList ListItemsCategories;


        public void OnGet(SearchProduct searchModel)
        {
            ListItemsCategories = new SelectList(_productCategoryApplication.GetSelectList(), "Id", "Name");

            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetSelectList()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var resualt = _productApplication.Add(command);
            return new JsonResult(resualt);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productcategory = _productApplication.GetDetails(id);
            productcategory.Categories = _productCategoryApplication.GetSelectList();
            return Partial("./Edit", productcategory);
        }

        public IActionResult OnGetNotInStock(long Id)
        {
            var resualt = _productApplication.NotInStock(Id);
            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGettInStock(long Id)
        {
            var resualt = _productApplication.IsStock(Id);
            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var resualt = _productApplication.Edit(command);
            return new JsonResult(resualt);
        }

    }
}