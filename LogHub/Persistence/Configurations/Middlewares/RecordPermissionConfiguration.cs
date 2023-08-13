using Domain.Entities.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Middlewares;

public class RecordPermissionConfiguration : IEntityTypeConfiguration<RecordPermission>
{
    public void Configure(EntityTypeBuilder<RecordPermission> builder)
    {
        builder.HasKey(p => new { p.UserId, p.RecordId });

        builder.HasOne(x => x.User)
            .WithMany(u => u.RecordPermissions)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(x => x.Record)
            .WithMany(r => r.Permissions)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.Level).IsRequired();

        builder.Property(p => p.UserId).IsRequired();

        builder.Property(p => p.RecordId).IsRequired();
    }
}