using LogHub.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class RecordConfiguration : IEntityTypeConfiguration<RecordEntity>
{
    public void Configure(EntityTypeBuilder<RecordEntity> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasConversion(
            recordId => recordId.Value,
            value => new RecordId(value));

        builder.HasMany(r => r.Requests)
            .WithOne()
            .HasForeignKey(r => r.RecordId);

        builder.HasMany(r => r.Actions)
            .WithOne()
            .HasForeignKey(r => r.RecordId);

        builder.HasMany(r => r.Permissions)
            .WithOne()
            .HasForeignKey(r => r.RecordId);

        builder.Property(r => r.Title).IsRequired();
    }
}
