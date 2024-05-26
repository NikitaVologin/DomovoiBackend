using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class UpdateCounterAgentRequestInheritanceConfiguration : JsonInheritanceConfiguration<CounterAgentUpdateRequest>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(LegalCounterAgentUpdateRequest), "Legal" },
        { typeof(PhysicalCounterAgentUpdateRequest), "Physical" }
    };
}