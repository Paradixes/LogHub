using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasConversion(
            department => department.Value,
            value => new DepartmentId(value));

        builder.Property(d => d.Name).IsRequired();

        builder.HasOne<Organisation>()
            .WithMany()
            .HasForeignKey(d => d.OrganisationId)
            .IsRequired();

        builder.HasMany<User>()
            .WithOne()
            .HasForeignKey(u => u.DepartmentId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(d => d.ManagerId);
    }
}
