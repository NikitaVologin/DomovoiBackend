using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.LivingBuildingsConfigurations;

public class FlatConfiguration : IEntityTypeConfiguration<Flat>
{
    public void Configure(EntityTypeBuilder<Flat> builder)
    {
        builder.ToTable("Flats");
        builder.HasOne(f => f.Building)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }
}