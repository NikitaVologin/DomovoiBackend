using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.Realities;

public class Reality
{
    [Key]
    public Guid Id { get; set; }
    public double Area { get; set; }
    public string? Type { get; set; }
}