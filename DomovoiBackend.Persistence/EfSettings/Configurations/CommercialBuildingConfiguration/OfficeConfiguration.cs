using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.CommercialBuildingConfiguration;

/// <summary>
/// Конфигурация офиса.
/// </summary>
public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable(nameof(Office));
    }
}