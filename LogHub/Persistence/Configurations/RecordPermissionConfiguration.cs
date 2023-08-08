using Domain.Entities.Middlewares;
using Domain.Entities.Records;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RecordPermissionConfiguration : IEntityTypeConfiguration<RecordPermission>
{
    public void Configure(EntityTypeBuilder<RecordPermission> builder)
    {
        builder.HasKey(p => new { p.UserId, p.RecordId });

        builder.HasOne<User>()
            .WithMany(u => u.RecordPermissions)
            .HasForeignKey(p => p.UserId);

        builder.HasOne<Record>()
            .WithMany(r => r.Permissions)
            .HasForeignKey(p => p.RecordId);

        builder.Property(p => p.Level).IsRequired();

        builder.Property(p => p.UserId).IsRequired();

        builder.Property(p => p.RecordId).IsRequired();
    }
}
