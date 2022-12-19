using DisCountManagement.Domain.CustomerDisCountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisCountManagement.Infrastrue.EFCore.Mapping
{
    public class CustomerDisCountMapping : IEntityTypeConfiguration<CustomerDisCount>
    {
        public void Configure(EntityTypeBuilder<CustomerDisCount> builder)
        {
            builder.HasKey(x => x.KeyId);

            builder.Property(x => x.Reason).HasMaxLength(500).IsRequired();

            builder.Property(x => x.DisCountRate).IsRequired();

            builder.Property(x => x.ProductId).IsRequired();


        }
    }
}
