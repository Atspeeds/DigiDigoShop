using _0_FrameWork.Domain;
using ShopManagement.Application.Contract.ProductPicture;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepositoryBase<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        IEnumerable<ProductPictureViewModel> Search(SearchProductPicture searchmodel);
    }
}
