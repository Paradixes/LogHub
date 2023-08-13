using Domain.Entities.Records.DataManagementPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Records;

public class DataManagementPlanTemplateConfiguration : IEntityTypeConfiguration<DataManagementPlanTemplate>
{
    public void Configure(EntityTypeBuilder<DataManagementPlanTemplate> builder)
    {
        builder.ToTable("DataManagementPlanTemplates");

        builder.HasOne(dmp => dmp.Organisation)
            .WithMany(o => o.DataManagementPlanTemplates)
            .HasForeignKey(dmp => dmp.OrganisationId);

        builder.Property(dmp => dmp.Title).IsRequired();
    }
}