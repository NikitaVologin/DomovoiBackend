using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos;

namespace DomovoiBackend.Application.Models.CounterAgents.RequestInfos;

public class LegalCounterAgentInformation : CounterAgentInformation,
    IMapTo<LegalCounterAgentInfo>,
    IMapFrom<LegalCounterAgent>
{
    public string? Name { get; set; }
    public string? Tin { get; set; }
    public string? Trc { get; set; }    
}