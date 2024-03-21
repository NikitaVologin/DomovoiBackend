using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Factories.AnnouncementFactory.Infos;
using DomovoiBackend.Domain.Factories.AnnouncementFactory.Interfaces;
using DomovoiBackend.Domain.Factories.CounterAgentFactories;
using DomovoiBackend.Domain.Factories.DealsFactories;
using DomovoiBackend.Domain.Factories.RealityFactories.Factories;

namespace DomovoiBackend.Domain.Factories.AnnouncementFactory;

public class AnnouncementFactory : IAnnouncementFactory
{
    private readonly BaseDealFactory _dealFactory = new();
    private readonly BaseCounterAgentFactory _counterAgentFactory = new();
    private readonly RealityFactory _realityFactory = new();
    
    public Announcement Generate(AnnouncementInfo info)
    {
        return new Announcement
        {
            Id = Guid.NewGuid(),
            ConnectionType = info.ConnectionType,
            Description = info.Description,
            Deal = _dealFactory.Generate(info.DealInfo),
            CounterAgent = _counterAgentFactory.Generate(info.CounterAgentInfo),
            Reality = _realityFactory.GenerateReality(info.RealityInfo)
        };
    }
}