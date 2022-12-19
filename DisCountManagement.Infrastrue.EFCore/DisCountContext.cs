using DisCountManagement.Domain.ColleagueDiscountAgg;
using DisCountManagement.Domain.CustomerDisCountAgg;
using DisCountManagement.Infrastrue.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
namespace DisCountManagement.Infrastrue.EFCore
{
    public class DisCountContext : DbContext
    {

        public DisCountContext(DbContextOptions<DisCountContext> options):base(options)
        {
        }

        #region DbSet And Entity Table In Sql
        public DbSet<CustomerDisCount> CustomerDisCounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assamble=typeof(CustomerDisCountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assamble);

            base.OnModelCreating(modelBuilder);
        }





    }
}
