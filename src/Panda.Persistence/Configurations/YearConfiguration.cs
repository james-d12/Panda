using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Years.Domain;

namespace Panda.Persistence.Configurations;
internal sealed class YearConfiguration : IEntityTypeConfiguration<Year>
{
    public void Configure(EntityTypeBuilder<Year> builder)
    {
        builder.HasKey(y => y.Id);

        builder.Property(y => y.Id).IsRequired().HasColumnOrder(0);
        builder.Property(y => y.Name).IsRequired().HasMaxLength(64).HasColumnOrder(1);
        builder.Property(y => y.Description).IsRequired().HasMaxLength(256).HasColumnOrder(2);
        builder.Property(y => y.Status).IsRequired().HasConversion<int>().HasColumnOrder(3);
        builder.Property(y => y.StartDate).IsRequired().HasColumnOrder(4);
        builder.Property(y => y.EndDate).IsRequired().HasColumnOrder(5);

        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasIndex(c => c.StartDate).IsUnique();
        builder.HasIndex(c => c.EndDate).IsUnique();

        builder
            .HasMany(y => y.Budgets)
            .WithOne(b => b.Year)
            .HasForeignKey(b => b.YearId)
            .HasPrincipalKey(y => y.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}