using Domain.Entities.Middlewares;
using Domain.Entities.Records.Docs;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class FavouriteDocConfiguration : IEntityTypeConfiguration<FavouriteDoc>
{
    public void Configure(EntityTypeBuilder<FavouriteDoc> builder)
    {
        builder.HasKey(x => new { x.DocId, x.UserId });

        builder.HasOne<Document>()
            .WithMany()
            .HasForeignKey(x => x.DocId);

        builder.HasOne<User>()
            .WithMany(u => u.FavouriteDocs)
            .HasForeignKey(x => x.UserId);

        builder.Property(x => x.DocId).IsRequired();

        builder.Property(x => x.UserId).IsRequired();
    }
}
