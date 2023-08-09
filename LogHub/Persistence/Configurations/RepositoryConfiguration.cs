using Domain.Entities.Records;
using Domain.Entities.Records.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RepositoryConfiguration : IEntityTypeConfiguration<Repository>
{
    public void Configure(EntityTypeBuilder<Repository> builder)
    {
        builder.ToTable("Repositories");

        builder.HasOne(r => r.Organisation)
            .WithMany(o => o.Repositories)
            .HasForeignKey(r => r.OrganisationId);

        builder.HasOne(r => r.DataManagementPlan)
            .WithOne(dmp => dmp.Repository)
            .HasForeignKey<Repository>(r => r.DataManagementPlanId);

        builder.HasOne<Record>()
            .WithOne()
            .HasForeignKey<Repository>(r => r.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(r => r.Title).IsRequired();
    }
}
