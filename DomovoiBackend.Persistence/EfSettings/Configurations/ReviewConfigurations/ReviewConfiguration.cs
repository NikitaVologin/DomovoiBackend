using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Entities.CounterAgents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.ReviewConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.Id).IsUnique();
        builder.HasIndex(r => r.DestinationId);
        builder.HasOne<CounterAgent>()
            .WithMany()
            .HasForeignKey(r => r.DestinationId);

        builder.HasOne<CounterAgent>(r => r.Author)
            .WithMany();
    }
}