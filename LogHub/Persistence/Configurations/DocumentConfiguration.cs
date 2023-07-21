using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Logbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Documents");

        builder.HasOne<Logbook>()
            .WithMany()
            .HasForeignKey(d => d.LogbookId);

        builder.HasMany(d => d.Labels)
            .WithOne()
            .HasForeignKey(l => l.DocId);

        builder.HasMany(d => d.Editors)
            .WithOne()
            .HasForeignKey(e => e.DocId);

        builder.Property(d => d.Status).IsRequired();

        builder.Property(r => r.Title).IsRequired();
    }
}
