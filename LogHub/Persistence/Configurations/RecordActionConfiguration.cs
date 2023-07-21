using LogHub.Domain.Entities.Actions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class RecordActionConfiguration : IEntityTypeConfiguration<RecordAction>
{
    public void Configure(EntityTypeBuilder<RecordAction> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            actionId => actionId.Value,
            value => new RecordActionId(value));

        builder.HasOne<RecordEntity<RecordId>>()
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.RecordId);

        builder.Property(a => a.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new RecordId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.InitiatorId);

        builder.Property(a => a.RecordType).IsRequired();

        builder.Property(a => a.Message).IsRequired();
    }
}
