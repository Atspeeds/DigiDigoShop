using _0_FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public interface IProductPictureApplication
    {
        OprationResualt Add(CreateProductPicture command);
        OprationResualt Edit(EditProductPicture command);
        OprationResualt Deleted(long id);
        OprationResualt Restore(long id);
        IEnumerable<ProductPictureViewModel> Search(SearchProductPicture searchmodel);
        EditProductPicture GetDetails(long id);
    }
}
