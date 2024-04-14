using DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction;

namespace DomovoiBackend.Domain.Entities.Deals.Rents;

public class Rent : Deal
{
    public virtual RentConditions? RentConditions { get; set; }
    public virtual RentRules? RentRules { get; set; }
}