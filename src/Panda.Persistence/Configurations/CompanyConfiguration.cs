using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Companies.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).IsRequired().HasColumnOrder(0);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(64).HasColumnOrder(1);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(256).HasColumnOrder(2);

        builder.HasIndex(c => c.Name).IsUnique();

        builder
            .HasMany(c => c.Budgets)
            .WithOne(b => b.Company)
            .HasForeignKey(b => b.CompanyId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}