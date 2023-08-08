using Domain.Entities.Middlewares;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrganisationMembershipConfiguration : IEntityTypeConfiguration<OrganisationMembership>
{
    public void Configure(EntityTypeBuilder<OrganisationMembership> builder)
    {
        builder.HasKey(x => new { x.OrganisationId, x.UserId });

        builder.HasOne<Organisation>()
            .WithMany(o => o.Memberships)
            .HasForeignKey(x => x.OrganisationId);

        builder.HasOne<User>()
            .WithMany(u => u.OrganisationMemberships)
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.OrganisationId).IsRequired();

        builder.Property(x => x.UserId).IsRequired();
    }
}
