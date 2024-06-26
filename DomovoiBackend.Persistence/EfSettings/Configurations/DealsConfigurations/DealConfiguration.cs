using DomovoiBackend.Domain.Entities.Deals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.DealsConfigurations;

/// <summary>
/// Конфигурация сделки.
/// </summary>
public class DealConfiguration : IEntityTypeConfiguration<Deal>
{
    public void Configure(EntityTypeBuilder<Deal> builder)
    {
        builder.HasKey(d => d.Id);
        builder.HasIndex(d => d.Id).IsUnique();
    }
}