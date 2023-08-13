using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasConversion(
            user => user.Value,
            value => new UserId(value));

        builder.HasIndex(u => u.Email).IsUnique();

        builder.OwnsOne(u => u.UserPreference);
    }
}