using _0_FrameWork.Application;
using _0_FrameWork.Query;
using _01_DigiDigoQuery.Contract.Invantory;
using _01_DigiDigoQuery.Contract.Product;
using DisCountManagement.Infrastrue.EFCore;
using InventoryManagement.Infrastrure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Infrastrure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_DigiDigoQuery.Query
{
    public class ProductQuery : IProductQuery
    {

         readonly ShopContext _shopContext;
         readonly InventoryContext _inventoryContext;
         readonly DisCountContext _disCountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DisCountContext disCountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _disCountContext = disCountContext;
        }

        public ProductQueryModel GetDetails(string slug)
        {

            var invantory = _inventoryContext.WareHouses.Select(x => new InvantoryQueryModel()
            {
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Stock = x.InStock
            }).ToList();

            var discount = _disCountContext.CustomerDisCounts
                .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.DisCountRate,
                    x.ProductId
                }).ToList();

            var product = _shopContext.Products
                .Include(p => p.ProductPictures)
               .Include(x => x.Category)
               .Select(x => new ProductQueryModel
               {
                   ProductId = x.KeyId,
                   ProductCategory = x.Category.Name,
                   CategorySlug = x.Category.Slug,
                   Name = x.Name,
                   Picture = x.Picture,
                   PictureAlt = x.PictureAlt,
                   PictureTitle = x.PictureTitle,
                   Slug = x.Slug,
                   Description = x.Description,
                   ShortDescription = x.ShortDescription,
                   Code = x.Code,
                   ProductPictures = MapProductPicture(x.ProductPictures),
               }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            if (product == null) return null;


            var Productinvantory = invantory.FirstOrDefault(x => x.ProductId == product.ProductId);
            var productDiscount = discount.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (Productinvantory != null)
            {

                var price = Productinvantory.UnitPrice;
                product.Price = Productinvantory.UnitPrice.ToMoney();
                product.Stock = Productinvantory.Stock;

                if (productDiscount != null)
                {

                    product.PriceWithDiscount = DiscountCalculations
                        .CalculationDiscountPercentage(price, productDiscount.DisCountRate).ToMoney();
                }

            }

            return product;


        }

         static List<ProductPictureQueryModel> MapProductPicture(List<ProductPicture> productPictures)
        {
            return productPictures.Where(p => !p.IsRemove)
                .Select(x => new ProductPictureQueryModel()
                {
                    Picture = x.Picture,
                    PictureTitle = x.PictureAlt,
                    IsRemove = x.IsRemove,
                    PictureAlt = x.PictureAlt
                }).ToList();
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

            var query = _shopContext.Products.Include(x => x.Category)
                .Select(product => new ProductQueryModel()
                {
                    ProductId = product.KeyId,
                    ProductCategory = product.Category.Name,
                    CategorySlug = product.Category.Slug,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,
                    ShortDescription = product.ShortDescription

                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));


            var products = query.OrderByDescending(x => x.ProductId).ToList();

            foreach (var product in products)
            {
                var productinvantory = invantory.FirstOrDefault(x => x.ProductId == product.ProductId);
                var productdiscount = discount.FirstOrDefault(x => x.ProductId == product.ProductId);

                if (productinvantory is not null)
                {
                    var price = productinvantory.UnitPrice;
                    product.Price = price.ToMoney();
                    if (productdiscount is not null)
                    {
                        product.PriceWithDiscount = DiscountCalculations.
                            CalculationDiscountPercentage(price, productdiscount.DisCountRate).ToMoney();
                    }
                }

            }

            return products;
        }

        public List<ProductQueryModel> GetRelatedProductsBy(ProductRelatedQueryModel command)
        {
            var invantory = _inventoryContext.WareHouses
                .Select(x => new { x.UnitPrice, x.ProductId }).ToList();

            var discount = _disCountContext.CustomerDisCounts
             .Where(d => d.StartDate < DateTime.Now && d.EndDate > DateTime.Now)
             .Select(x => new { x.ProductId, x.DisCountRate }).ToList();

            var Product = _shopContext.Products.Include(c => c.Category)
                .Where(s => s.Category.Slug == command.CategorySlug && s.KeyId != command.ProductId)
               .Select(x => new ProductQueryModel()
               {
                   ProductId = x.KeyId,
                   CategorySlug = x.Category.Slug,
                   Name = x.Name,
                   Picture = x.Picture,
                   PictureAlt = x.PictureAlt,
                   PictureTitle = x.PictureTitle,
                   Slug = x.Slug,
               }).AsNoTracking().OrderByDescending(x => x.ProductId).Take(6).ToList();

            foreach (var product in Product)
            {
                var unitprice = invantory.FirstOrDefault(x => x.ProductId == product.ProductId);
                var discountprice = discount.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (unitprice is not null)
                {
                    var price = unitprice.UnitPrice;
                    product.Price = price.ToMoney();
                    if (discountprice is not null)
                    {
                        product.DiscountRate = discountprice.DisCountRate;
                        product.PriceWithDiscount = DiscountCalculations
                         .CalculationDiscountPercentage(price, discountprice.DisCountRate).ToMoney();
                    }
                }
            }

            return Product;

        }
    }
}
