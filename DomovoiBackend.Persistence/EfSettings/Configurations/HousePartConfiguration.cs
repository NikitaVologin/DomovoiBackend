using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class HousePartConfiguration : IEntityTypeConfiguration<HousePart>
{
    public void Configure(EntityTypeBuilder<HousePart> builder)
    {
        builder.ToTable(nameof(HousePart));
    }
}