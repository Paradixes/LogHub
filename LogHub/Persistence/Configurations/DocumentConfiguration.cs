using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasConversion(
            documentId => documentId.Value,
            value => new DocumentId(value));

        builder.HasOne<Logbook>()
            .WithMany()
            .HasForeignKey(d => d.LogbookId);

        builder.Property(d => d.Status).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
