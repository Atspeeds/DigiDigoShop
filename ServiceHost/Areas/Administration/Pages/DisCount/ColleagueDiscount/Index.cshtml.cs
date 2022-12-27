using DisCountManagement.Application.Contract.ColleagueDiscount;
using DisCountManagement.Application.Contract.CustomerDisCount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceHost.Areas.Administration.Pages.DisCount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {

        [TempData]
        public string Message { get; set; }
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDisCountViewModel> ColleagueDisCounts;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;

        public IndexModel(IProductApplication ProductApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = ProductApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetSelectList(), "Id", "Name");
            ColleagueDisCounts = _colleagueDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new AddColleagueDisCount
            {
                productViews = _productApplication.GetSelectList()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(AddColleagueDisCount command)
        {
            var result = _colleagueDiscountApplication.Defind(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var colleagueDiscount = _colleagueDiscountApplication.GetDetails(id);

            colleagueDiscount.productViews = _productApplication.GetSelectList();

            return Partial("./Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDisCount command)
        {
            var result = _colleagueDiscountApplication.Edit(command);

            return new JsonResult(result);

        }

        public IActionResult OnGetRemove(long id)
        {
            _colleagueDiscountApplication.Delete(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
