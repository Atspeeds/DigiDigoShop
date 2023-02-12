using _0_FrameWork.Application;
using _0_FrameWork.Query;
using _01_DigiDigoQuery.Contract.Product;
using _01_DigiDigoQuery.Contract.ProductCategory;
using DisCountManagement.Infrastrue.EFCore;
using InventoryManagement.Infrastrure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastrure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01_DigiDigoQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        private readonly InventoryContext _inventoryContext;

        private readonly DisCountContext _discountContext;
        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DisCountContext disCountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = disCountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(x =>
            new ProductCategoryQueryModel
            {
                ID = x.KeyId,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CategorySlug = x.Slug
            }).AsNoTracking().ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var inventory = _inventoryContext.WareHouses.Select(x =>
                 new { x.ProductId, x.UnitPrice }).ToList();

            var Discount = _discountContext.CustomerDisCounts
                .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.ProductId,
                    x.DisCountRate,
                    x.Reason,
                })
                .ToList();



            var categories = _shopContext.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    ID = x.KeyId,
                    Name = x.Name,
                    Products = MapProducts(x.Products),
                    CategorySlug = x.Slug
                }).ToList();

            foreach (var category in categories)
            {
                foreach (var item in category.Products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == item.ProductId);
                    var discount = Discount.FirstOrDefault(x => x.ProductId == item.ProductId);
                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        item.Price = price.ToMoney();
                        if (discount != null)
                        {
                            item.PriceWithDiscount = DiscountCalculations
                                .CalculationDiscountPercentage(price, discount.DisCountRate).ToMoney();

                        }

                    }

                }
            }



            return categories;

        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {

            return products.Select(product => new ProductQueryModel
            {
                ProductId = product.KeyId,
                ProductCategory = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug
            }).ToList();


        }

        public ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug)
        {
            var inventory = _inventoryContext.WareHouses
                .Select(x => new { x.UnitPrice, x.ProductId }).ToList();

            var discount = _discountContext.CustomerDisCounts
                .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.ProductId,
                    x.DisCountRate,
                    x.Reason,
                })
                .ToList();

            var product = _shopContext.ProductCategories
                 .Include(p => p.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel()
                {
                    ID = x.KeyId,
                    Name = x.Name,
                    Description = x.Description,
                    CategorySlug = x.Slug,
                    Products = MapProducts(x.Products)
                }).FirstOrDefault(x => x.CategorySlug == slug);

            foreach (var products in product.Products)
            {
                var productPrice = inventory.FirstOrDefault(x => x.ProductId == products.ProductId);
                var productDiscount = discount.FirstOrDefault(x => x.ProductId == products.ProductId);

                if (productPrice != null)
                {
                    var price = productPrice.UnitPrice;
                    products.Price = price.ToMoney();
                    if (productDiscount != null)
                    {
                        var discountRate = productDiscount.DisCountRate;
                        products.DiscountRate = discountRate;


                        products.PriceWithDiscount = DiscountCalculations
                            .CalculationDiscountPercentage(price, discountRate).ToMoney();

                    }

                }
            }

            return product;

        }

      
    }
}
