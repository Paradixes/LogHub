using Domain.Entities.Records;
using Domain.Entities.Records.DataManagementPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DataManagementPlanConfiguration : IEntityTypeConfiguration<DataManagementPlan>
{
    public void Configure(EntityTypeBuilder<DataManagementPlan> builder)
    {
        builder.ToTable("DataManagementPlans");

        builder.Property(dmp => dmp.RepositoryId)
            .HasConversion(baseId => baseId.Value,
                value => new RecordId(value));

        builder.HasOne(dmp => dmp.Repository)
            .WithOne(r => r.DataManagementPlan)
            .HasForeignKey<DataManagementPlan>(dmp => dmp.RepositoryId);
    }
}
