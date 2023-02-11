using _01_DigiDigoQuery.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DigiDigoQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
        ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug);
    }
}
