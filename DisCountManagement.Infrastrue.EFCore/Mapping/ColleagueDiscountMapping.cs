using DisCountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisCountManagement.Infrastrue.EFCore.Mapping
{
    public class ColleagueDiscountMapping : IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.ToTable("ColleagueDiscount");
            builder.HasKey(x => x.KeyId);

            builder.Property(x => x.DisCountRate).IsRequired();
            builder.Property(x => x.DisCountRate).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();


        }
    }
}
