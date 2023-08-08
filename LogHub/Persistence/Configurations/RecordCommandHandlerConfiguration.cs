using Domain.Entities.Middlewares;
using Domain.Entities.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RecordCommandHandlerConfiguration : IEntityTypeConfiguration<RecordCommandHandler>
{
    public void Configure(EntityTypeBuilder<RecordCommandHandler> builder)
    {
        builder.HasKey(x => new { x.RecordId, x.Command });


        builder.HasOne<Record>()
            .WithMany(r => r.CommandHandlers)
            .HasForeignKey(x => x.RecordId);

        builder.Property(x => x.RecordId).IsRequired();

        builder.Property(x => x.Command).IsRequired();

        builder.Property(x => x.Level).IsRequired();
    }
}
