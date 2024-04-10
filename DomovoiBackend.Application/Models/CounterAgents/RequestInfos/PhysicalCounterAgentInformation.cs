using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Models.CounterAgents.RequestInfos;

public class PhysicalCounterAgentInformation : CounterAgentInformation,
    IMapTo<PhysicalCounterAgentInfo>,
    IMapFrom<PhysicalCounterAgent>
{
    public string? FIO { get; set; }
    public string? PassportData { get; set; }
}