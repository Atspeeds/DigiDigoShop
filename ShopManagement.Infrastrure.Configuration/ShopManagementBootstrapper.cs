﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastrure.EFCore;
using ShopManagement.Infrastrure.EFCore.Repository;

namespace ShopManagement.Infrastrure.Con
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            //ProductCategory
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            //Product
            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();

            //Used Sql Server
            service.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

        }

    }
}
