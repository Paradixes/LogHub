using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Requests;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DmpRequestConfiguration : IEntityTypeConfiguration<RecordRequest<DmpRequestId, DmpId>>
{
    public void Configure(EntityTypeBuilder<RecordRequest<DmpRequestId, DmpId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            projectId => projectId.Value,
            value => new DmpRequestId(value));

        builder.HasOne<DataManagementPlan>()
            .WithMany(r => r.Requests)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new DmpId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.InitiatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.HandlerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Message).IsRequired();
    }
}

public class BaseRequestConfiguration : IEntityTypeConfiguration<RecordRequest<BaseRequestId, BaseId>>
{
    public void Configure(EntityTypeBuilder<RecordRequest<BaseRequestId, BaseId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            projectId => projectId.Value,
            value => new BaseRequestId(value));

        builder.HasOne<Base>()
            .WithMany(r => r.Requests)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new BaseId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.InitiatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.HandlerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Message).IsRequired();
    }
}

public class LogbookRequestConfiguration : IEntityTypeConfiguration<RecordRequest<LogbookRequestId, LogbookId>>
{
    public void Configure(EntityTypeBuilder<RecordRequest<LogbookRequestId, LogbookId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            projectId => projectId.Value,
            value => new LogbookRequestId(value));

        builder.HasOne<Logbook>()
            .WithMany(r => r.Requests)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new LogbookId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.InitiatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.HandlerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Message).IsRequired();
    }
}

public class DocRequestConfiguration : IEntityTypeConfiguration<RecordRequest<DocRequestId, DocumentId>>
{
    public void Configure(EntityTypeBuilder<RecordRequest<DocRequestId, DocumentId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            projectId => projectId.Value,
            value => new DocRequestId(value));

        builder.HasOne<Document>()
            .WithMany(r => r.Requests)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new DocumentId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.InitiatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.HandlerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Message).IsRequired();
    }
}
