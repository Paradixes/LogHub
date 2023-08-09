using Domain.Entities.Records.DataManagementPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id).HasConversion(
            questionId => questionId.Value,
            value => new QuestionId(value));

        builder.HasOne(q => q.DataManagementPlan)
            .WithMany(dmp => dmp.Questions)
            .HasForeignKey(q => q.DataManagementPlanId);

        builder.Property(q => q.Title).IsRequired();
    }
}
