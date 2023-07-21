using LogHub.Domain.Entities.Requests;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class RecordRequestConfiguration : IEntityTypeConfiguration<RecordRequest>
{
    public void Configure(EntityTypeBuilder<RecordRequest> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            projectId => projectId.Value,
            value => new RecordRequestId(value));

        builder.HasOne<RecordEntity>()
            .WithMany(r => r.Requests)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new RecordId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.InitiatorId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.HandlerId);

        builder.Property(p => p.RecordType).IsRequired();

        builder.Property(p => p.Message).IsRequired();
    }
}
