using Domain.Entities.Records;
using Domain.Entities.Records.Logbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class LogbookConfiguration : IEntityTypeConfiguration<Logbook>
{
    public void Configure(EntityTypeBuilder<Logbook> builder)
    {
        builder.ToTable("Logbooks");

        builder.HasOne(l => l.Repository)
            .WithMany(r => r.Logbooks)
            .HasForeignKey(l => l.RepositoryId);

        builder.HasOne<Record>()
            .WithOne()
            .HasForeignKey<Logbook>(l => l.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(l => l.Importance).IsRequired();
    }
}
