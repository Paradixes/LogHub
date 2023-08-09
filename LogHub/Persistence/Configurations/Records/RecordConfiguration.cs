using Domain.Entities.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Records;

public class RecordConfiguration : IEntityTypeConfiguration<Record>
{
    public void Configure(EntityTypeBuilder<Record> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasConversion(
            baseId => baseId.Value,
            value => new RecordId(value));

        builder.Property(r => r.Title).IsRequired();
    }
}