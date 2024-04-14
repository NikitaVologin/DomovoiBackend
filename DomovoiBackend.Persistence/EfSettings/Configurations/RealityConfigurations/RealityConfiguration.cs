using DomovoiBackend.Domain.Entities.Realities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.RealityConfigurations;

/// <summary>
/// Конфигурация недвижимости.
/// </summary>
public class RealityConfiguration : IEntityTypeConfiguration<Reality>
{
    public void Configure(EntityTypeBuilder<Reality> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.Id).IsUnique();
        builder.ToTable(nameof(Reality));
    }
}