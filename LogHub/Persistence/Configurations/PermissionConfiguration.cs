using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            permissionId => permissionId.Value,
            value => new PermissionId(value));

        builder.Property(p => p.Level).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.HasOne<RecordEntity>()
            .WithMany()
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.RecordId).HasConversion(
            recordId => recordId.Value,
            value => new RecordId(value));
    }
}
