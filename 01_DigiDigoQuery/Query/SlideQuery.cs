using _01_DigiDigoQuery.Contract.Slide;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastrure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_DigiDigoQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slides.Where(x => x.IsRemove == false)
                 .Select(x => new SlideQueryModel()
                 {
                     BtnText = x.BtnText,
                     Heading = x.Heading,
                     Picture = x.Picture,
                     PictureAlt = x.PictureAlt,
                     PictureTitle = x.PictureTitle,
                     Text = x.Text,
                     Title = x.Title,
                 }).ToList();
        }

    }
}

