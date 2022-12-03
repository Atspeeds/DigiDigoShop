using _0_FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Slide
{
    public interface ISlideApplication
    {
        OprationResualt Add(CreateSlide command);
        OprationResualt Edit(EditSlide command);
        OprationResualt Delete(long id);
        OprationResualt Restore(long id);
        IEnumerable<SlideViewModel> All();
        EditSlide GetDetails(long id);
    }
}
