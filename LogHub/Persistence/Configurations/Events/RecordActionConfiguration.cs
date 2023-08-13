using Domain.Entities.Events.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Events;

public class RecordActionConfiguration : IEntityTypeConfiguration<RecordAction>
{
    public void Configure(EntityTypeBuilder<RecordAction> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            actionId => actionId.Value,
            value => new RecordActionId(value));

        builder.HasOne(a => a.Record)
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.RecordId);

        builder.HasOne(u => u.Initiator)
            .WithMany(u => u.RecordActions)
            .HasForeignKey(a => a.InitiatorId);

        builder.Property(a => a.Message).IsRequired();

        builder.Property(a => a.InitiatorId).IsRequired();
    }
}