using DomovoiBackend.Domain.Entities.Realities.Areas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.OtherBuildingConfigurations;

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable(nameof(Area));
    }
}