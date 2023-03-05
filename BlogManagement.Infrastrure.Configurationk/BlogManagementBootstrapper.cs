using BlogManagement.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastrure.EfCore;
using BlogManagement.Infrastrure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastrure.Configurationk
{
    public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {

            #region ShopManagement_IOC
            //ProductCategory
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            #endregion


            //Used Sql Server
            service.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        }


    }
}
