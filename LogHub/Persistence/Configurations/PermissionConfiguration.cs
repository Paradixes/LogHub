using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DmpPermissionConfiguration : IEntityTypeConfiguration<RecordPermission<DmpPermissionId, DmpId>>
{
    public void Configure(EntityTypeBuilder<RecordPermission<DmpPermissionId, DmpId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            permissionId => permissionId.Value,
            value => new DmpPermissionId(value));

        builder.Property(p => p.Level).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.HasOne<DataManagementPlan>()
            .WithMany()
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new DmpId(value));
    }
}

public class BasePermissionConfiguration : IEntityTypeConfiguration<RecordPermission<BasePermissionId, BaseId>>
{
    public void Configure(EntityTypeBuilder<RecordPermission<BasePermissionId, BaseId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            permissionId => permissionId.Value,
            value => new BasePermissionId(value));

        builder.Property(p => p.Level).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.HasOne<Base>()
            .WithMany()
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new BaseId(value));
    }
}

public class LogbookPermissionConfiguration : IEntityTypeConfiguration<RecordPermission<LogbookPermissionId, LogbookId>>
{
    public void Configure(EntityTypeBuilder<RecordPermission<LogbookPermissionId, LogbookId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            permissionId => permissionId.Value,
            value => new LogbookPermissionId(value));

        builder.Property(p => p.Level).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.HasOne<Logbook>()
            .WithMany()
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new LogbookId(value));
    }
}

public class DocPermissionConfiguration : IEntityTypeConfiguration<RecordPermission<DocPermissionId, DocumentId>>
{
    public void Configure(EntityTypeBuilder<RecordPermission<DocPermissionId, DocumentId>> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            permissionId => permissionId.Value,
            value => new DocPermissionId(value));

        builder.Property(p => p.Level).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.HasOne<Document>()
            .WithMany()
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new DocumentId(value));
    }
}
