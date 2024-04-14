using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.CounterAgentConfigurations;

/// <summary>
/// Конфигурация физического контр-агента.
/// </summary>
public class PhysicalCounterAgentConfiguration : IEntityTypeConfiguration<PhysicalCounterAgent>
{
    public void Configure(EntityTypeBuilder<PhysicalCounterAgent> builder)
    {
        builder.ToTable(nameof(PhysicalCounterAgent));
    }
}