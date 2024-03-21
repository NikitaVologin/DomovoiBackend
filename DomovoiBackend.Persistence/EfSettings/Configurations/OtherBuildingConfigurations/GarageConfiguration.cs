using DomovoiBackend.Domain.Entities.Realities.Garages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class GarageConfiguration : IEntityTypeConfiguration<Garage>
{
    public void Configure(EntityTypeBuilder<Garage> builder)
    {
        builder.ToTable(nameof(Garage));
    }
}