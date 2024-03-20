using DomovoiBackend.Domain.Entities.Announcements.CounterAgents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class CounterAgentConfiguration : IEntityTypeConfiguration<CounterAgent>
{
    public void Configure(EntityTypeBuilder<CounterAgent> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id).IsUnique();
    }
}