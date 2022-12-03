using _0_FrameWork.Domain;
using ShopManagement.Application.Contract.Slide;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepositoryBase<long, Slide>
    {
        List<SlideViewModel> GetAll();
        EditSlide GetDetails(long id);

    }
}
