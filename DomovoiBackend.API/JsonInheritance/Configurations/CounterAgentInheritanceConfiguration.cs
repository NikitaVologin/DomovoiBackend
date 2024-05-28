using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Information.CounterAgents;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class CounterAgentInheritanceConfiguration : JsonInheritanceConfiguration<CounterAgentInformation>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(LegalCounterAgentInformation), CounterAgentStringLiteral.Legal },
        { typeof(PhysicalCounterAgentInformation), CounterAgentStringLiteral.Physical }
    };
}