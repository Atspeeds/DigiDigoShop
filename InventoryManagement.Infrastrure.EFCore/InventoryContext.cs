using InventoryManagement.Domain.WareHouseAgg;
using InventoryManagement.Infrastrure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastrure.EFCore
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {
        }

        #region DbSet And Entity Table In Sql
        public DbSet<WareHouse> WareHouses { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assamble = typeof(WareHouseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assamble);
            base.OnModelCreating(modelBuilder);
        }

    }
}
