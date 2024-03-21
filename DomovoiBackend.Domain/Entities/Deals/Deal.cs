using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Announcements.Deals;

public class Deal
{
    [Key]
    public Guid Id { get; set; }
}