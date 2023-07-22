using LogHub.Domain.Entities.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id).HasConversion(
            labelId => labelId.Value,
            value => new LabelId(value));

        builder.Property(l => l.Name).IsRequired();

        builder.HasOne<Base>()
            .WithMany(p => p.Labels)
            .HasForeignKey(l => l.BaseId);
    }
}
