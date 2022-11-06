using _0_FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OprationResualt Add(CreateProductCategory command);
        OprationResualt Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        IEnumerable<ProductCategoryViewModel> Search(SearchProductCategory searchModel);
        List<ProductCategoryViewModel> GetSelectList();

    }
}
