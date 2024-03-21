using System.ComponentModel.DataAnnotations.Schema;
using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell.Addiction;

namespace DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell;

public class Sell : Deal
{
    public virtual SellConditions? SellConditions { get; set; }
    public virtual SellFeatures? SellFeatures { get; set; }
}