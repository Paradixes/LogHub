using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Organisations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DataManagementPlanConfiguration : IEntityTypeConfiguration<DataManagementPlan>
{
    public void Configure(EntityTypeBuilder<DataManagementPlan> builder)
    {
        builder.ToTable("DataManagementPlans");

        builder.Property(dmp => dmp.Title).IsRequired();

        builder.HasMany(dmp => dmp.Questions)
            .WithOne()
            .HasForeignKey(q => q.DataManagementPlanId);

        builder.HasOne<Organisation>()
            .WithMany(o => o.DataManagementPlans)
            .HasForeignKey(dmp => dmp.OrganisationId);

        builder.Property(r => r.Title).IsRequired();
    }
}
