using Domain.Entities.Bases;
using Domain.Entities.Logbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class LogbookConfiguration : IEntityTypeConfiguration<Logbook>
{
    public void Configure(EntityTypeBuilder<Logbook> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id).HasConversion(
            logbookId => logbookId.Value,
            value => new LogbookId(value));

        builder.ToTable("Logbooks");

        builder.HasOne<Base>()
            .WithMany()
            .HasForeignKey(l => l.BaseId);

        builder.Property(l => l.Importance).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
