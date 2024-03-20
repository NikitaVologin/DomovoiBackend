using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class LivingBuildingConfiguration : IEntityTypeConfiguration<LivingBuilding>
{
    public void Configure(EntityTypeBuilder<LivingBuilding> builder)
    {
        builder.ToTable(nameof(LivingBuilding));
    }
}