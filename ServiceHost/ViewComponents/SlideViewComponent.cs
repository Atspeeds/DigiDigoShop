using _01_DigiDigoQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slidequery)
        {
            _slideQuery = slidequery;
        }

        public IViewComponentResult Invoke()
        {
            var SlideModel= _slideQuery.GetSlides();

            return View(SlideModel);
        }
    }
}
