﻿using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasConversion(
            organisation => organisation.Value,
            value => new OrganisationId(value));

        builder.Property(o => o.Name).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.ManagerId);

        builder.HasMany(o => o.Departments)
            .WithOne()
            .HasForeignKey(d => d.OrganisationId);

        builder.HasMany(o => o.DataManagementPlans)
            .WithOne()
            .HasForeignKey(dmp => dmp.OrganisationId);
    }
}