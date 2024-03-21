using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.LivingBuildingsConfigurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Id).IsUnique();
    }
}