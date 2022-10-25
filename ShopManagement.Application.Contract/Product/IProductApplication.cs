using _0_FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {

        OprationResualt Add(CreateProduct command);
        OprationResualt Edit(EditProduct command);
        EditProduct GetDetails(long id);
        IEnumerable<ProductViewModel> Search(SearchProduct searchModel);
        OprationResualt IsStock(long id);
        OprationResualt NotInStock(long id);


    }
}
