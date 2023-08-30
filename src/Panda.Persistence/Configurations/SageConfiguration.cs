using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Panda.Core.Modules.Sages.Domain;

namespace Panda.Persistence.Configurations;
internal sealed class SageConfiguration : IEntityTypeConfiguration<Sage>
{
    public void Configure(EntityTypeBuilder<Sage> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).IsRequired().HasColumnOrder(0);
        builder.Property(s => s.SageAccountId).IsRequired().HasColumnOrder(1);
        builder.Property(s => s.CategoryId).IsRequired().HasColumnOrder(2);

        builder.HasIndex(s => new { s.SageAccountId, s.CategoryId }).IsUnique();
    }
}