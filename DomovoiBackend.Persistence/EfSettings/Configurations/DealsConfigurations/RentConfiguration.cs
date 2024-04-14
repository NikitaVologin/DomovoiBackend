using DomovoiBackend.Domain.Entities.Deals.Rents;
using DomovoiBackend.Domain.Entities.Deals.Types.Rent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.DealsConfigurations;

public class RentConfiguration : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.ToTable(nameof(Rent));
    }
}