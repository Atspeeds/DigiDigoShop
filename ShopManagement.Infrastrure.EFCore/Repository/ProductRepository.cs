using _0_FrameWork.Infrastrure;
using _01_Framework.Infrastrure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastrure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {

        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            var product = _context.Products
                .Select(x => new EditProduct()
                {
                    Id = x.KeyId,
                    Name = x.Name,
                    Code = x.Code,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    ShortDescription = x.ShortDescription,
                    Slug = x.Slug,
                    KeyWords = x.KeyWords,
                    MetaDescription = x.MetaDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    UnitPrice = x.UnitPrice,

                }).FirstOrDefault(x => x.Id == id);

            return product;
        }


        public IEnumerable<ProductViewModel> Search(SearchProduct searchModel)
        {
            var query = _context.Products.Select(x =>
             new ProductViewModel()
             {
                 Id = x.KeyId,
                 Name = x.Name,
                 Category = x.Category.Name,
                 Code = x.Code,
                 UnitPrice = x.UnitPrice,
                 CategoryId = x.CategoryId,
                 Picture = x.Picture,
                 CreationDate = x.CreationDate.ToShamsi(),
                 IsInStock=x.IsInStock
             });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.AsNoTracking().OrderByDescending(x => x.Id).ToList();

        }

    }
}
