using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.Common;

public class Elevator
{
    [Key]
    public Guid Id { get; set; }
    public string? Type { get; set; }
}