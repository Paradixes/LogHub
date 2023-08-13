using Domain.Entities.Records;
using Domain.Entities.Records.Docs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Records;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents");

        builder.HasOne(d => d.Logbook)
            .WithMany(l => l.Documents)
            .HasForeignKey(d => d.LogbookId);

        builder.HasOne<Record>()
            .WithOne()
            .HasForeignKey<Document>(l => l.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(d => d.Status).IsRequired();
    }
}