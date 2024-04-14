using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.CommercialBuildingConfiguration;

/// <summary>
/// Конфигурация сущности коммерческой недвижимости.
/// </summary>
public class CommercialBuildingConfiguration : IEntityTypeConfiguration<CommercialBuilding>
{
    public void Configure(EntityTypeBuilder<CommercialBuilding> builder)
    {
        builder.ToTable(nameof(CommercialBuilding));
    }
}