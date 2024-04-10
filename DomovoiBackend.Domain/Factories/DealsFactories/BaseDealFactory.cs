using System.Reflection;
using DomovoiBackend.Domain.Entities.Announcements.Deals;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.DealsFactories;

public class BaseDealFactory : IDealFactory
{
    private static readonly Dictionary<Type, IDealFactory>
        CurrentFactories = GetOtherBuildingFactory(Assembly.GetExecutingAssembly());
    
    
    public Deal Generate(BaseDealInfo info, Guid announcementId) =>
        CurrentFactories[info.GetType()].Generate(info, announcementId);

    private static Dictionary<Type, IDealFactory> GetOtherBuildingFactory(Assembly assembly)
    {
        var factoryTypes = assembly
            .GetTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType &&
                                                         i.GetGenericTypeDefinition() ==
                                                         typeof(IDealFactory<,>)));
        return factoryTypes.ToDictionary(
            type => type.GetInterfaces()[0].GetGenericArguments()[0],
            type => (IDealFactory)Activator.CreateInstance(type, [])!);
    }
}