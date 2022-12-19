using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastrure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _Context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _Context.ProductPictures.Select(x => new EditProductPicture
            {
                Id = x.KeyId,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<ProductPictureViewModel> Search(SearchProductPicture searchmodel)
        {
            var query = _Context.ProductPictures.Include(x => x.Product)
                .Select(x => new ProductPictureViewModel()
                {
                    Picture = x.Picture,
                    IsRemoved = x.IsRemove,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Name = x.Product.Name,
                    Id = x.KeyId,
                    DataTime = x.CreationDate.ToFarsi()
                });


            if (searchmodel.Id != 0)
                query = query.Where(x => x.Id == searchmodel.Id);


            return query.AsNoTracking().OrderByDescending(x => x.Id).ToList();

        }

    }
}
