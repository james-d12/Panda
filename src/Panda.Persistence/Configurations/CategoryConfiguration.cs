using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Categories.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).IsRequired().HasColumnOrder(0);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(64).HasColumnOrder(1);
        builder.Property(c => c.Status).IsRequired().HasConversion<int>().HasColumnOrder(2);
        builder.Property(c => c.CategoryField).IsRequired().HasConversion<int>().HasColumnOrder(3);
        builder.Property(c => c.CategoryType).IsRequired().HasConversion<int>().HasColumnOrder(4);
        builder.Property(c => c.BudgetId).IsRequired().HasColumnOrder(5);

        builder.HasIndex(c => new { c.BudgetId, c.Name }).IsUnique();

        builder
            .HasMany(c => c.Sages)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}