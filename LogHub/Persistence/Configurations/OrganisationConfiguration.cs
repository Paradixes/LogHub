using Domain.Entities.Organisations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasConversion(
            organisation => organisation.Value,
            value => new OrganisationId(value));

        builder.HasOne(o => o.ParentOrganisation)
            .WithMany(o => o.SubOrganisations)
            .HasForeignKey(o => o.ParentOrganisationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.RootOrganisation)
            .WithMany()
            .HasForeignKey(o => o.RootOrganisationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(o => o.Name).IsRequired();
    }
}
