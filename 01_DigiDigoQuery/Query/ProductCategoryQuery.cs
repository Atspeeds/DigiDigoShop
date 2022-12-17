using _01_DigiDigoQuery.Contract.ProductCategory;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastrure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_DigiDigoQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(x =>
            new ProductCategoryQueryModel
            {
                ID=x.KeyId,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).AsNoTracking().ToList();
        }

    }
}
