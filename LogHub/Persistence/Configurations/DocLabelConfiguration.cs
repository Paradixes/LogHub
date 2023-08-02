using Domain.Entities.Bases;
using Domain.Entities.Docs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DocLabelConfiguration : IEntityTypeConfiguration<DocLabel>
{
    public void Configure(EntityTypeBuilder<DocLabel> builder)
    {
        builder.HasKey(x => new { x.DocId, x.LabelId });

        builder.Property(x => x.DocId).HasConversion(
            docId => docId.Value,
            value => new DocumentId(value));

        builder.Property(x => x.LabelId).HasConversion(
            labelId => labelId.Value,
            value => new LabelId(value));

        builder.HasOne<Label>()
            .WithMany()
            .HasForeignKey(x => x.LabelId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
