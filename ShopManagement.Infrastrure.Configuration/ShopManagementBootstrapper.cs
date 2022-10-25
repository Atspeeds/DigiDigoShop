using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.ProductCategory;
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


            //Used Sql Server
            service.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

        }

    }
}
