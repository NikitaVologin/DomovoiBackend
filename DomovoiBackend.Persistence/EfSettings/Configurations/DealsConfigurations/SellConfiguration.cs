using DomovoiBackend.Domain.Entities.Deals.Sells;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.DealsConfigurations;

/// <summary>
/// Конфигурация продаж.
/// </summary>
public class SellConfiguration : IEntityTypeConfiguration<Sell>
{
    public void Configure(EntityTypeBuilder<Sell> builder)
    {
        builder.ToTable(nameof(Sell));
        builder.HasOne(s => s.SellConditions)
            .WithOne()
            .HasForeignKey<SellConditions>(sc => sc.Id);
        builder.HasOne(s => s.SellFeatures)
            .WithOne()
            .HasForeignKey<SellFeatures>(sf => sf.Id);
    }
}