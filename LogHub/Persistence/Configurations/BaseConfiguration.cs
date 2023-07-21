using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.Organisations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class BaseConfiguration : IEntityTypeConfiguration<Base>
{
    public void Configure(EntityTypeBuilder<Base> builder)
    {
        builder.ToTable("Bases");

        builder.HasMany(b => b.Labels)
            .WithOne()
            .HasForeignKey(l => l.RecordId);

        builder.HasOne<Organisation>()
            .WithMany()
            .HasForeignKey(b => b.OrganisationId);

        builder.Property(b => b.Title).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
