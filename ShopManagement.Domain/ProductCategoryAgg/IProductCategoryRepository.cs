using _0_FrameWork.Domain;
using ShopManagement.Application.Contract.ProductCategory;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepositoryBase<long, ProductCategory>
    {
        IEnumerable<ProductCategoryViewModel> Search(SearchProductCategory search);
        EditProductCategory GetDetails(long id);
    }
}
