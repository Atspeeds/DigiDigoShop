using _0_FrameWork.Infrastrure;
using _01_Framework.Infrastrure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastrure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {

        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }


        public List<SlideViewModel> GetAll()
        {
            var slid = _context.Slides.Select(x => new SlideViewModel()
            {
                Id=x.KeyId,
                Title = x.Title,
                CreationDate = x.CreationDate.ToShamsi(),
                Heading = x.Heading,
                IsRemove = x.IsRemove,
                Picture = x.Picture,
                Text = x.Text,
                Link= x.Link,
            });

            return slid.AsNoTracking().OrderByDescending(x => x.Id).ToList();
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide()
            {
                Id = x.KeyId,
                Heading = x.Heading,
                Picture = x.Picture,
                Text = x.Text,
                Title = x.Title,
                BtnText= x.BtnText,
                PictureAlt= x.PictureAlt,
                PictureTitle= x.PictureTitle,
                Link= x.Link,

            }).FirstOrDefault(x => x.Id == id);
        }

    }
}
