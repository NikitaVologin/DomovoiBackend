using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell.Addiction;

public class SellConditions
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string? Type { get; set; }
}