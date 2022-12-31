using InventoryManagement.Domain.WareHouseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastrure.EFCore.Mapping
{
    public class WareHouseMapping : IEntityTypeConfiguration<WareHouse>
    {
        public void Configure(EntityTypeBuilder<WareHouse> builder)
        {
            builder.HasKey(x => x.KeyId);
            builder.ToTable("WareHouses");

            builder.OwnsMany(x => x.Oprations, ModelBullder =>
            {
                ModelBullder.ToTable("Oprations");
                ModelBullder.HasKey(x => x.Id);


                ModelBullder.Property(x => x.Description).HasMaxLength(1000);

                ModelBullder.WithOwner(x => x.WareHouse).HasForeignKey(x => x.WareHouseID);
            });
        }
    }
}
