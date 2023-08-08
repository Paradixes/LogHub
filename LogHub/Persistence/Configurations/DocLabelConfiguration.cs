using Domain.Entities.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DocLabelConfiguration : IEntityTypeConfiguration<DocLabel>
{
    public void Configure(EntityTypeBuilder<DocLabel> builder)
    {
        builder.HasKey(x => new { x.DocId, x.LabelId });

        builder.HasOne(x => x.Label)
            .WithMany()
            .HasForeignKey(x => x.LabelId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Doc)
            .WithMany(d => d.Labels)
            .HasForeignKey(x => x.DocId);

        builder.Property(x => x.DocId).IsRequired();

        builder.Property(x => x.LabelId).IsRequired();
    }
}
