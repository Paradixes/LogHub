using Domain.Entities.Docs;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class FavouriteDocConfiguration : IEntityTypeConfiguration<FavouriteDoc>
{
    public void Configure(EntityTypeBuilder<FavouriteDoc> builder)
    {
        builder.HasKey(x => new { x.DocId, x.UserId });

        builder.Property(x => x.DocId).HasConversion(
            docId => docId.Value,
            value => new DocumentId(value));

        builder.Property(x => x.UserId).HasConversion(
            userId => userId.Value,
            value => new UserId(value));

        builder.HasOne<Document>()
            .WithMany()
            .HasForeignKey(x => x.DocId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
