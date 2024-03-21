namespace DomovoiBackend.Domain.Entities.CounterAgents.Types;

public class PhysicalCounterAgent : CounterAgent
{
    public string? FIO { get; set; }
    public string? PassportData { get; set; }
}