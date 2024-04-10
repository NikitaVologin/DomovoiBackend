using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.Deals;

public class Deal
{
    [Key]
    public Guid Id { get; set; }
}