using Domain.Entities.Middlewares;
using Domain.Entities.Records;
using Domain.Entities.Records.Docs;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DocEditorConfiguration : IEntityTypeConfiguration<DocEditor>
{
    public void Configure(EntityTypeBuilder<DocEditor> builder)
    {
        builder.HasKey(x => new { x.DocId, x.UserId });

        builder.Property(x => x.DocId)
            .HasConversion(docId => docId.Value,
                value => new RecordId(value));

        builder.HasOne<Document>()
            .WithMany(d => d.Editors)
            .HasForeignKey(x => x.DocId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.DocId).IsRequired();

        builder.Property(x => x.UserId).IsRequired();
    }
}
