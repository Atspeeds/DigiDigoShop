using CommentManagement.Application.Conteract.Comment;
using InventoryManagement.Application.Contract.WareHouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Comment
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly ICommentApplication _commentApplication;

        private readonly IProductApplication _productApplication;

        public IndexModel(ICommentApplication commentApplication, IProductApplication productApplication)
        {
            _commentApplication = commentApplication;
            _productApplication = productApplication;
        }

        public SelectList Products;
        public List<CommentViewModel> comments;
        public CommentSearchModel searchModel;

        public void OnGet(CommentSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetSelectList(), "Id", "Name");
            comments = _commentApplication.SearchBy(searchModel);
        }
       
        public IActionResult OnGetConfirmation(int id)
        {
            var resualt=_commentApplication.Confirmation(id);
            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetReJection(int id)
        {
            var resualt = _commentApplication.Reject(id);
            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");
        }


    }
}
