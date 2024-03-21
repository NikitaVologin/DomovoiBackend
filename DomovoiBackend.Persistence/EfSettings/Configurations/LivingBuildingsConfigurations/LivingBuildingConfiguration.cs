using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.LivingBuildingsConfigurations;

public class LivingBuildingConfiguration : IEntityTypeConfiguration<LivingBuilding>
{
    public void Configure(EntityTypeBuilder<LivingBuilding> builder)
    {
        builder.ToTable(nameof(LivingBuilding));
    }
}