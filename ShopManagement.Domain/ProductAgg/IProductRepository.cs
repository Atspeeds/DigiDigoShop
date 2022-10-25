using _0_FrameWork.Domain;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepositoryBase<long, Product>
    {
        EditProduct GetDetails(long id);
        IEnumerable<ProductViewModel> Search(SearchProduct searchModel);
    }
}
