using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class BathroomConfiguration : IEntityTypeConfiguration<Bathroom>
{
    public void Configure(EntityTypeBuilder<Bathroom> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.Id).IsUnique();
    }
}