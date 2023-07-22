using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DataManagementPlanTemplateConfiguration : IEntityTypeConfiguration<DataManagementPlanTemplate>
{
    public void Configure(EntityTypeBuilder<DataManagementPlanTemplate> builder)
    {
        builder.HasKey(dmp => dmp.Id);

        builder.Property(dmp => dmp.Id).HasConversion(
            dmpId => dmpId.Value,
            value => new DmpId(value));

        builder.Property(dmp => dmp.Title).IsRequired();

        builder.HasOne<Organisation>()
            .WithMany(o => o.DataManagementPlanTemplates)
            .HasForeignKey(dmp => dmp.OrganisationId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(dmp => dmp.CreatorId);

        builder.Property(r => r.Title).IsRequired();
    }
}
