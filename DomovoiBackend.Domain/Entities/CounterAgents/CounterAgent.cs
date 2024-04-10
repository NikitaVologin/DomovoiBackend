using System.ComponentModel.DataAnnotations;

namespace DomovoiBackend.Domain.Entities.CounterAgents;

public class CounterAgent
{
    [Key]
    public Guid Id { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}