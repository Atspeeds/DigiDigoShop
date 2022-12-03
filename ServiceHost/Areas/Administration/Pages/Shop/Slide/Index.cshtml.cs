using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Slide;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public IEnumerable<SlideViewModel> SlideModels;


        public void OnGet()
        {
            SlideModels = _slideApplication.All();
        }

        public IActionResult OnGetCreate()
        {
            var Slide = new CreateSlide() {};
            return Partial("./Create", Slide);
        }


        public JsonResult OnPostCreate(CreateSlide command)
        {
            var resualt = _slideApplication.Add(command);
            return new JsonResult(resualt);
        }


        public IActionResult OnGetEdit(long id)
        {
            var slider = _slideApplication.GetDetails(id);

            return Partial("./Edit", slider);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var resualt = _slideApplication.Edit(command);

            return new JsonResult(resualt);
        } 

        public IActionResult OnGetRemove(long id)
        {
            var resualt=_slideApplication.Delete(id);

            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var resualt = _slideApplication.Restore(id);
            if (resualt.IsSuccedded)
                return RedirectToPage("./Index");

            Message = resualt.Message;
            return RedirectToPage("./Index");
        }

    }
}
