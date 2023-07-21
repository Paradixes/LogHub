using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.Logbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class LogbookConfiguration : IEntityTypeConfiguration<Logbook>
{
    public void Configure(EntityTypeBuilder<Logbook> builder)
    {
        builder.ToTable("Logbooks");

        builder.HasOne<Base>()
            .WithMany()
            .HasForeignKey(l => l.BaseId);

        builder.Property(l => l.Importance).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
