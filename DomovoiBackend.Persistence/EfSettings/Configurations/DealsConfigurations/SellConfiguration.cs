using DomovoiBackend.Domain.Entities.Deals.Sells;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.DealsConfigurations;

public class SellConfiguration : IEntityTypeConfiguration<Sell>
{
    public void Configure(EntityTypeBuilder<Sell> builder)
    {
        builder.ToTable(nameof(Sell));
    }
}