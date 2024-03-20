using DomovoiBackend.Domain.Entities.Announcements.CounterAgents.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class PhysicalCounterAgentConfiguration : IEntityTypeConfiguration<PhysicalCounterAgent>
{
    public void Configure(EntityTypeBuilder<PhysicalCounterAgent> builder)
    {
        builder.ToTable(nameof(PhysicalCounterAgent));
    }
}