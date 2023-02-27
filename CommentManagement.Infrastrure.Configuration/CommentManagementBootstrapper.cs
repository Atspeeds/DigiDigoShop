using CommentManagement.Application;
using CommentManagement.Application.Conteract.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastrure.EFCore;
using CommentManagement.Infrastrure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Infrastrure.Configuration
{
    public class CommentManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connection)
        {
            #region ShopManagement_IOC
            //Comment
            service.AddTransient<ICommentApplication, CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();
            #endregion


            //Used Sql Server
            service.AddDbContext<CommentContext>(options => options.UseSqlServer(connection));

        }
    }
}
