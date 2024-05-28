using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class UpdateCounterAgentRequestInheritanceConfiguration : JsonInheritanceConfiguration<CounterAgentUpdateRequest>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(LegalCounterAgentUpdateRequest), CounterAgentStringLiteral.Legal },
        { typeof(PhysicalCounterAgentUpdateRequest), CounterAgentStringLiteral.Physical }
    };
}