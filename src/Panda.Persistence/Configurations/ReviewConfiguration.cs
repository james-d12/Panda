using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Reviews.Domain;
using Panda.Core.Modules.Tables.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).IsRequired().HasColumnOrder(0);
        builder.Property(r => r.YearId).IsRequired().HasColumnOrder(1);
        builder.Property(r => r.Status).IsRequired().HasConversion<int>().HasColumnOrder(2);

        builder.HasIndex(r => r.YearId).IsUnique();

        builder
            .HasOne(r => r.Table)
            .WithOne(t => t.Review)
            .HasForeignKey<Table>(t => t.ReviewId)
            .HasPrincipalKey<Review>(r => r.Id);
    }
}
