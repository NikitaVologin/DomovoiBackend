using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;

namespace DomovoiBackend.Application.Models.CounterAgents;

public class AddCounterAgentRequest
{
    public CounterAgentInformation CounterAgentInfo { get; set; } = null!;
}