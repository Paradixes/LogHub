using Domain.Entities.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Middlewares;

public class FavouriteDocConfiguration : IEntityTypeConfiguration<FavouriteDoc>
{
    public void Configure(EntityTypeBuilder<FavouriteDoc> builder)
    {
        builder.HasKey(x => new { x.DocId, x.UserId });

        builder.HasOne(x => x.Doc)
            .WithMany()
            .HasForeignKey(x => x.DocId);

        builder.HasOne(x => x.User)
            .WithMany(u => u.FavouriteDocs)
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.DocId).IsRequired();

        builder.Property(x => x.UserId).IsRequired();
    }
}