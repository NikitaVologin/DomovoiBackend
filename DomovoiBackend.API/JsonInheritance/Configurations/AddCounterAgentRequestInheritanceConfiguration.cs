using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class AddCounterAgentRequestInheritanceConfiguration : JsonInheritanceConfiguration<AddCounterAgentRequest>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(AddLegalCounterAgentRequest), "Legal" },
        { typeof(AddPhysicalCounterAgentRequest), "Physical" }
    };
}