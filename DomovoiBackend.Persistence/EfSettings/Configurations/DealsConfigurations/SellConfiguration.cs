using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell;
using DomovoiBackend.Domain.Entities.Deals.Types.Sell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations;

public class SellConfiguration : IEntityTypeConfiguration<Sell>
{
    public void Configure(EntityTypeBuilder<Sell> builder)
    {
        builder.ToTable(nameof(Sell));
    }
}