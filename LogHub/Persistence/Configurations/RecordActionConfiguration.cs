﻿using LogHub.Domain.Entities.Actions;
using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DmpActionConfiguration : IEntityTypeConfiguration<RecordAction<DmpActionId, DmpId>>
{
    public void Configure(EntityTypeBuilder<RecordAction<DmpActionId, DmpId>> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            actionId => actionId.Value,
            value => new DmpActionId(value));

        builder.HasOne<DataManagementPlan>()
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.RecordId);

        builder.Property(a => a.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new DmpId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.InitiatorId);

        builder.Property(a => a.Message).IsRequired();
    }
}

public class BaseActionConfiguration : IEntityTypeConfiguration<RecordAction<BaseActionId, BaseId>>
{
    public void Configure(EntityTypeBuilder<RecordAction<BaseActionId, BaseId>> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            actionId => actionId.Value,
            value => new BaseActionId(value));

        builder.HasOne<Base>()
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.RecordId);

        builder.Property(a => a.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new BaseId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.InitiatorId);

        builder.Property(a => a.Message).IsRequired();
    }
}

public class LogbookActionConfiguration : IEntityTypeConfiguration<RecordAction<LogbookActionId, LogbookId>>
{
    public void Configure(EntityTypeBuilder<RecordAction<LogbookActionId, LogbookId>> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            actionId => actionId.Value,
            value => new LogbookActionId(value));

        builder.HasOne<Logbook>()
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.RecordId);

        builder.Property(a => a.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new LogbookId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.InitiatorId);

        builder.Property(a => a.Message).IsRequired();
    }
}

public class DocActionConfiguration : IEntityTypeConfiguration<RecordAction<DocActionId, DocumentId>>
{
    public void Configure(EntityTypeBuilder<RecordAction<DocActionId, DocumentId>> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            actionId => actionId.Value,
            value => new DocActionId(value));

        builder.HasOne<Document>()
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.RecordId);

        builder.Property(a => a.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new DocumentId(value));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.InitiatorId);

        builder.Property(a => a.Message).IsRequired();
    }
}
