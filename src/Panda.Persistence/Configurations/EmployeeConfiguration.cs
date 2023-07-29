using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Persistence.Configurations;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired().HasColumnOrder(0);
        builder.Property(e => e.Role).IsRequired().HasConversion<int>().HasColumnOrder(1);
        builder.Property(e => e.Username).IsRequired().HasMaxLength(64).HasColumnOrder(2);
        builder.Property(e => e.EmailAddress).IsRequired().HasMaxLength(128).HasColumnOrder(3);

        builder.HasIndex(e => e.Username).IsUnique();
        builder.HasIndex(e => e.EmailAddress).IsUnique();
    }
}
