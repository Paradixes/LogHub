using LogHub.Domain.Entities.DataManagementPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogHub.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id).HasConversion(
            questionId => questionId.Value,
            value => new QuestionId(value));

        builder.HasOne<DataManagementPlan>()
            .WithMany()
            .HasForeignKey(q => q.DmpId);

        builder.Property(q => q.Title).IsRequired();
    }
}