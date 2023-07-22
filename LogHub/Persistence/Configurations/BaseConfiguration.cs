using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Organisations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class BaseConfiguration : IEntityTypeConfiguration<Base>
{
    public void Configure(EntityTypeBuilder<Base> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            baseId => baseId.Value,
            value => new BaseId(value));

        builder.HasOne<Organisation>()
            .WithMany()
            .HasForeignKey(b => b.OrganisationId);

        builder.HasOne<DataManagementPlan>()
            .WithMany()
            .HasForeignKey(b => b.DmpId);

        builder.Property(b => b.Title).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
