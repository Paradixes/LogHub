using Domain.Entities.Events.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Events;

public class RecordRequestConfiguration : IEntityTypeConfiguration<RecordRequest>
{
    public void Configure(EntityTypeBuilder<RecordRequest> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasConversion(
            requestId => requestId.Value,
            value => new RecordRequestId(value));

        builder.HasOne(r => r.Handler)
            .WithMany(u => u.RequestToHandle)
            .HasForeignKey(r => r.HandlerId);

        builder.HasOne(a => a.Record)
            .WithMany(r => r.Requests)
            .HasForeignKey(a => a.RecordId);

        builder.HasOne(r => r.Initiator)
            .WithMany(u => u.RequestToInitiate)
            .HasForeignKey(r => r.InitiatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(r => r.Message).IsRequired();

        builder.Property(r => r.Status).IsRequired();

        builder.Property(r => r.HandlerId).IsRequired();
    }
}