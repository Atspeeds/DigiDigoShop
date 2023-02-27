using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommentManagement.Infrastrure.EFCore.Mapping
{
    internal class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.KeyId);

            builder.Property(x => x.Message).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(500).IsRequired();


        }
    }
}
