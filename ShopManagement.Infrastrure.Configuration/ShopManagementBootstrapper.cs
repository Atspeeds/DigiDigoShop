using _01_DigiDigoQuery.Contract.Product;
using _01_DigiDigoQuery.Contract.ProductCategory;
using _01_DigiDigoQuery.Contract.Slide;
using _01_DigiDigoQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastrure.EFCore;
using ShopManagement.Infrastrure.EFCore.Repository;

namespace ShopManagement.Infrastrure.Con
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            #region ShopManagement_IOC
            //ProductCategory
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            //Product
            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();

            //ProductPicture
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            //Slide
            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();

            #endregion


            #region QueryIOC
            //Slider
            service.AddTransient<ISlideQuery, SlideQuery>();

            //ProductCategory
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();

            //Product
            service.AddTransient<IProductQuery, ProductQuery>();
            #endregion


            //Used Sql Server
            service.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

        }

    }
}
