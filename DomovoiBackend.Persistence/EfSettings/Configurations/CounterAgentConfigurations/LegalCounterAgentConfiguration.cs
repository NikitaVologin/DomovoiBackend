using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.CounterAgentConfigurations;

/// <summary>
/// Конфигурация юридического контр-агента.
/// </summary>
public class LegalCounterAgentConfiguration : IEntityTypeConfiguration<LegalCounterAgent>
{
    public void Configure(EntityTypeBuilder<LegalCounterAgent> builder)
    {
        builder.ToTable(nameof(LegalCounterAgent));
    }
}