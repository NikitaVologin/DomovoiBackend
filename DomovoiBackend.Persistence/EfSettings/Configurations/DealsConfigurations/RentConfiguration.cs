using DomovoiBackend.Domain.Entities.Deals.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.DealsConfigurations;

/// <summary>
/// Конфигурация аренды.
/// </summary>
public class RentConfiguration : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable(nameof(Rent));
        builder.HasOne(r => r.Conditions)
            .WithOne()
            .HasForeignKey<RentConditions>(rc => rc.Id);
    }
}