namespace DomovoiBackend.Domain.Entities.CounterAgents.Types;

public class LegalCounterAgent : CounterAgent
{
    public string? Name { get; set; }
    public string? Tin { get; set; }
    public string? Trc { get; set; }
}