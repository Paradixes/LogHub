using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Organisations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DataManagementPlanConfiguration : IEntityTypeConfiguration<DataManagementPlan>
{
    public void Configure(EntityTypeBuilder<DataManagementPlan> builder)
    {
        builder.HasKey(dmp => dmp.Id);

        builder.Property(dmp => dmp.Id).HasConversion(
            dmpId => dmpId.Value,
            value => new DataManagementPlanId(value));

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
