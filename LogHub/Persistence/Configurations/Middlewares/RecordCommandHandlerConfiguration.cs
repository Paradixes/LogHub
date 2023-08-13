using Domain.Entities.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Middlewares;

public class RecordCommandHandlerConfiguration : IEntityTypeConfiguration<RecordCommandHandler>
{
    public void Configure(EntityTypeBuilder<RecordCommandHandler> builder)
    {
        builder.HasKey(x => new { x.RecordId, x.Command });


        builder.HasOne(x => x.Record)
            .WithMany(r => r.CommandHandlers)
            .HasForeignKey(x => x.RecordId);

        builder.Property(x => x.RecordId).IsRequired();

        builder.Property(x => x.Command).IsRequired();

        builder.Property(x => x.Level).IsRequired();
    }
}