using Domain.Entities.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Middlewares;

public class OrganisationMembershipConfiguration : IEntityTypeConfiguration<OrganisationMembership>
{
    public void Configure(EntityTypeBuilder<OrganisationMembership> builder)
    {
        builder.HasKey(x => new { x.OrganisationId, x.UserId });

        builder.HasOne(x => x.Organisation)
            .WithMany(o => o.Memberships)
            .HasForeignKey(x => x.OrganisationId);

        builder.HasOne(u => u.User)
            .WithMany(u => u.OrganisationMemberships)
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.OrganisationId).IsRequired();

        builder.Property(x => x.UserId).IsRequired();
    }
}