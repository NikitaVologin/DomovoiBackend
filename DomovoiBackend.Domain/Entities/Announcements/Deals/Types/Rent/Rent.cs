using System.ComponentModel.DataAnnotations.Schema;
using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Rent.Addiction;

namespace DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Rent;

public class Rent : Deal
{
    public virtual RentConditions? RentConditions { get; set; }
    public virtual RentRules? RentRules { get; set; }
}