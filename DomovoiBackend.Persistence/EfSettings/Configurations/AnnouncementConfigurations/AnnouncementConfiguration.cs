using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Realities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomovoiBackend.Persistence.EfSettings.Configurations.AnnouncementConfigurations;

/// <summary>
/// Кофигурация сущности объявлений.
/// </summary>
public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable(nameof(Announcement));
        builder.HasIndex(a => a.Id).IsUnique();
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.Deal)
            .WithOne()
            .HasForeignKey<Deal>(d => d.Id);

        builder.HasOne(a => a.Reality)
            .WithOne()
            .HasForeignKey<Reality>(r => r.Id);
    }
}