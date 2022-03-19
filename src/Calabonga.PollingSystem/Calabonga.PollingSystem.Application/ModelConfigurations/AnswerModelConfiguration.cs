using Calabonga.PollingSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calabonga.PollingSystem.Application.ModelConfigurations
{
    public class AnswerModelConfiguration: IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(512);
            builder.Property(x => x.Votes);
            builder.Property(x => x.Percents);
        }
    }
}
