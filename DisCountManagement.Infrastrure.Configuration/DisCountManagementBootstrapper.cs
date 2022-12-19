using DisCountManagement.Application;
using DisCountManagement.Application.Contract.CustomerDisCount;
using DisCountManagement.Domain.CustomerDisCountAgg;
using DisCountManagement.Infrastrue.EFCore;
using DisCountManagement.Infrastrue.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DisCountManagement.Infrastrure.Configuration
{
    public class DisCountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connection)
        {

            #region IOC Mannagement
            //CustomerDisCount
            services.AddTransient<ICustomerDisCountApplication, CustomerDisCountApplication>();
            services.AddTransient<ICustomerDisCountRepository, CustomerDisCountRepository>();

            #endregion




            //Used Sql Server
            services.AddDbContext<DisCountContext>(option =>
            {
                option.UseSqlServer(connection);
            });

        }
    }
}
