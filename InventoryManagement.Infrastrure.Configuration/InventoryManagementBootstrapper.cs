using InventoryManagement.Application;
using InventoryManagement.Application.Contract.WareHouse;
using InventoryManagement.Domain.WareHouseAgg;
using InventoryManagement.Infrastrure.EFCore;
using InventoryManagement.Infrastrure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastrure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            #region ShopManagement_IOC
            //WareHouse
            services.AddTransient<IWareHouseApplication, WareHouseApplication>();
            services.AddTransient<IWareHouseRepository, WareHouseRepository>();

            #endregion



            //Used Sql Server
            services.AddDbContext<InventoryContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


        }
    }
}
