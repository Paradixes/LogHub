using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasConversion(
            user => user.Value,
            value => new UserId(value));

        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasOne<Organisation>()
            .WithMany()
            .HasForeignKey(u => u.OrganisationId)
            .IsRequired();

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(u => u.DepartmentId)
            .IsRequired(false);

        builder.OwnsOne(u => u.UserSetting);
    }
}
