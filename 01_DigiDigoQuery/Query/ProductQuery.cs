using _0_FrameWork.Application;
using _0_FrameWork.Query;
using _01_DigiDigoQuery.Contract.Product;
using DisCountManagement.Infrastrue.EFCore;
using InventoryManagement.Infrastrure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastrure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01_DigiDigoQuery.Query
{
    public class ProductQuery : IProductQuery
    {

        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DisCountContext _disCountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DisCountContext disCountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _disCountContext = disCountContext;
        }

        public ProductQueryModel GetDetails(string slug)
        {
            var invantory = _inventoryContext.WareHouses.Select(x => new
            {
                x.ProductId,
                x.UnitPrice
            }).ToList();

            var discount = _disCountContext.CustomerDisCounts
                .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.DisCountRate,
                    x.ProductId
                }).ToList();

            var product = _shopContext.Products
               .Include(x => x.Category)
               .Select(x => new ProductQueryModel
               {
                   ProductId = x.KeyId,
                   ProductCategory = x.Category.Name,
                   Name = x.Name,
                   Picture = x.Picture,
                   PictureAlt = x.PictureAlt,
                   PictureTitle = x.PictureTitle,
                   Slug = x.Slug,
                   Description = x.Description,
                   ShortDescription = x.ShortDescription,
                   Code = x.Code,

               }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            if (product == null) return null;


            var Productinvantory = invantory.FirstOrDefault(x => x.ProductId == product.ProductId);
            var productDiscount = discount.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (Productinvantory != null)
            {
                var price = Productinvantory.UnitPrice;
                product.Price = Productinvantory.UnitPrice.ToMoney();
                if (productDiscount != null)
                {
                    product.PriceWithDiscount = DiscountCalculations
                        .CalculationDiscountPercentage(price, productDiscount.DisCountRate).ToMoney();
                }

            }

            return product;


        }

        public List<ProductQueryModel> GetLatestArrival()
        {

            var invantory = _inventoryContext.WareHouses
                .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var discount = _disCountContext.CustomerDisCounts
                .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DisCountRate }).ToList();

            var product = _shopContext.Products.Include(x => x.Category)
                .Select(product => new ProductQueryModel()
                {
                    ProductId = product.KeyId,
                    ProductCategory = product.Category.Name,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,

                }).OrderByDescending(x => x.ProductId).Take(6).ToList();


            foreach (var item in product)
            {
                var productInvantory = invantory
                    .FirstOrDefault(x => x.ProductId == item.ProductId);

                var productDiscount = discount
                    .FirstOrDefault(x => x.ProductId == item.ProductId);

                if (productInvantory != null)
                {
                    var price = productInvantory.UnitPrice;
                    item.Price = price.ToMoney();
                    if (productDiscount != null)
                    {
                        item.PriceWithDiscount = DiscountCalculations
                            .CalculationDiscountPercentage(price, productDiscount.DisCountRate).ToMoney();
                    }


                }

            }

            return product;

        }

        public List<ProductQueryModel> Search(string value)
        {

            var invantory = _inventoryContext.WareHouses.Select(x => new
            {
                x.ProductId,
                x.UnitPrice
            }).ToList();


            var discount = _disCountContext.CustomerDisCounts
                .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.ProductId,
                    x.DisCountRate
                }).ToList();

            var query = _shopContext.Products.Include(c => c.Category)
                .Select(x => new ProductQueryModel()
                {
                    ProductId = x.KeyId,
                    Code = x.Code,
                    Name = x.Name,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ProductCategory = x.Category.Name
                });

            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value.ToLower()) ||
                  x.ShortDescription.Contains(value.ToLower())).
                  OrderByDescending(x => x.ProductId);

            var products = query.OrderByDescending(x => x.ProductId).AsNoTracking().ToList();

            foreach (var product in products)
            {
                var price = invantory.FirstOrDefault(x => x.ProductId == product.ProductId).UnitPrice;
                var discountRate = discount.FirstOrDefault(x => x.ProductId == product.ProductId).DisCountRate;

                if (price is not 0)
                {
                    product.Price = price.ToMoney();
                    if (discountRate is not 0)
                    {
                        product.PriceWithDiscount = DiscountCalculations.
                            CalculationDiscountPercentage(price, discountRate).ToMoney();
                    }
                }
            }

            return products;
        }
    }
}
