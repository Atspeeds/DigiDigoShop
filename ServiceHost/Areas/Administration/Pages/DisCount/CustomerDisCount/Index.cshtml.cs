using DisCountManagement.Application.Contract.CustomerDisCount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.DisCount.CoustomerDisCount
{
    public class IndexModel : PageModel
    {

        private readonly ICustomerDisCountApplication _customerDisCountApplication;

        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDisCountApplication customerDisCountApplication, IProductApplication productApplication)
        {
            _customerDisCountApplication = customerDisCountApplication;
            _productApplication = productApplication;
        }


        public IEnumerable<CustomerDisCountViewModel> CustomerDiscounts;

        public SelectList products;

        public CustomerDisCountSearchModel searchModel;


        public void OnGet(CustomerDisCountSearchModel searchModel)
        {
            products = new SelectList(_productApplication.GetSelectList(), "Id", "Name");
            CustomerDiscounts = _customerDisCountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new AddCustomerDiscount()
            {
                productViews = _productApplication.GetSelectList(),
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(AddCustomerDiscount command)
        {
            var resualt = _customerDisCountApplication.Defind(command);

            return new JsonResult(resualt);
        }

        public IActionResult OnGetEdit(int id)
        {
            var command = _customerDisCountApplication.GetDetails(id);
            command.productViews = _productApplication.GetSelectList();
            return Partial("./Edit", command);
        }

        public IActionResult OnPostEdit(EditCustomerDiscount command)
        {
            var resualt = _customerDisCountApplication.Edit(command);
            return new JsonResult(resualt);
        }

    }
}
