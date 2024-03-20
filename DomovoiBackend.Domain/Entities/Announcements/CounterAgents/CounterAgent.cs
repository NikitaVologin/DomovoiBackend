using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Announcements.CounterAgents;

public class CounterAgent
{
    [Key]
    public Guid Id { get; set; }
    public string? ContactNumber { get; set; }
}