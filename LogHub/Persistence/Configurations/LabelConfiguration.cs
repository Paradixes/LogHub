using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id).HasConversion(
            labelId => labelId.Value,
            value => new LabelId(value));

        builder.HasOne<Repository>()
            .WithMany(r => r.Labels)
            .HasForeignKey(l => l.RepositoryId);

        builder.Property(l => l.Name).IsRequired();
    }
}
