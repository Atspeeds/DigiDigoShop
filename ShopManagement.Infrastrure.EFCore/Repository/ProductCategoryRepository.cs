using _0_FrameWork.Application;
using _0_FrameWork.Infrastrure;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastrure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _Context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            var Productcategory = _Context.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.KeyId,
                Name = x.Name,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            })
            .Where(x => x.Id == id).FirstOrDefault();

            return Productcategory;
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _Context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id=x.KeyId,
                Name=x.Name
            }).ToList();
        }

        public IEnumerable<ProductCategoryViewModel> Search(SearchProductCategory search)
        {
            var query = _Context.ProductCategories.Select(x =>
            new ProductCategoryViewModel()
            {
                Id = x.KeyId,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
            });

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));

            return query.OrderByDescending(x => x.Id).ToList();

        }


    }
}
