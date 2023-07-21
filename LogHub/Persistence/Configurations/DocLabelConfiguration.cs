using LogHub.Domain.Entities.Bases;
using LogHub.Domain.Entities.Docs;
using LogHub.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class DocLabelConfiguration : IEntityTypeConfiguration<DocLabel>
{
    public void Configure(EntityTypeBuilder<DocLabel> builder)
    {
        builder.HasKey(x => new { x.DocId, x.LabelId });

        builder.Property(x => x.DocId).HasConversion(
            docId => docId.Value,
            value => new RecordId(value));

        builder.Property(x => x.LabelId).HasConversion(
            labelId => labelId.Value,
            value => new LabelId(value));
    }
}
