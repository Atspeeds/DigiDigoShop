using InventoryManagement.Application.Contract.WareHouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {

        private readonly IWareHouseApplication _wareHouseApplication;

        private readonly IProductApplication _productApplication;

        public IndexModel(IWareHouseApplication wareHouseApplication, IProductApplication productApplication)
        {
            _wareHouseApplication = wareHouseApplication;
            _productApplication = productApplication;
        }


        public IEnumerable<WareHouseViewModel> wareHouseModel;

        public SelectList products;

        public WareHouseSearchModel searchModel;


        public void OnGet(WareHouseSearchModel searchModel)
        {
            products = new SelectList(_productApplication.GetSelectList(), "Id", "Name");
            wareHouseModel = _wareHouseApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateWareHouse()
            {
                ProductViews = _productApplication.GetSelectList(),
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateWareHouse command)
        {
            var resualt = _wareHouseApplication.Add(command);

            return new JsonResult(resualt);
        }

        public IActionResult OnGetEdit(int id)
        {
            var command = _wareHouseApplication.GetDetails(id);
            command.ProductViews = _productApplication.GetSelectList();
            return Partial("./Edit", command);
        }

        public IActionResult OnPostEdit(EditeWareHouse command)
        {
            var resualt = _wareHouseApplication.Edit(command);
            return new JsonResult(resualt);
        }

    }
}
