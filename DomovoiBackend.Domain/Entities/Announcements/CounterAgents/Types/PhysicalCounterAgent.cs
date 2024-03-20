using System.ComponentModel.DataAnnotations.Schema;

namespace DomovoiBackend.Domain.Entities.Announcements.CounterAgents.Types;

public class PhysicalCounterAgent : CounterAgent
{
    public string? FIO { get; set; }
    public string? PassportData { get; set; }
}