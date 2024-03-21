using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Domain.Factories.AnnouncementFactory.Infos;

public record AnnouncementInfo(
    string Description,
    string ConnectionType,
    BaseRealityInfo RealityInfo,
    BaseDealInfo DealInfo,
    BaseCounterAgentInfo CounterAgentInfo);