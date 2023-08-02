using Domain.Entities.Bases;
using Domain.Entities.DataManagementPlans;
using Domain.Entities.Organisations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

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

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(b => b.DepartmentId);

        builder.HasOne<DataManagementPlan>()
            .WithMany()
            .HasForeignKey(b => b.DmpId);

        builder.Property(b => b.Title).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
