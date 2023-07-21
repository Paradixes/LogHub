using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DocEditorConfiguration : IEntityTypeConfiguration<DocEditor>
{
    public void Configure(EntityTypeBuilder<DocEditor> builder)
    {
        builder.HasKey(x => new { x.DocId, x.UserId });

        builder.Property(x => x.DocId).HasConversion(
            docId => docId.Value,
            value => new RecordId(value));

        builder.Property(x => x.UserId).HasConversion(
            userId => userId.Value,
            value => new UserId(value));
    }
}
