using Domain.Entities.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Middlewares;

public class OrganisationSettingConfiguration : IEntityTypeConfiguration<OrganisationSetting>
{
    public void Configure(EntityTypeBuilder<OrganisationSetting> builder)
    {
        builder.HasKey(s => new { s.OrganisationId, s.Option });

        builder.HasOne(s => s.Organisation)
            .WithMany(o => o.Settings)
            .HasForeignKey(s => s.OrganisationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.Role).IsRequired();
    }
}
