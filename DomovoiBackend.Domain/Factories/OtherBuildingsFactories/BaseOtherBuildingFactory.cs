using System.Reflection;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories;

public class BaseOtherBuildingFactory : IOtherBuildingFactory
{
    private static readonly Dictionary<Type, IOtherBuildingFactory>
        CurrentFactories = GetOtherBuildingFactory(Assembly.GetExecutingAssembly());
    
    
    public Reality Generate(BaseOtherBuildingInfo info) =>
        CurrentFactories[info.GetType()].Generate(info);

    private static Dictionary<Type, IOtherBuildingFactory> GetOtherBuildingFactory(Assembly assembly)
    {
        var factoryTypes = assembly
            .GetTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType &&
                                                         i.GetGenericTypeDefinition() ==
                                                         typeof(IOtherBuildingFactory<,>)));
        return factoryTypes.ToDictionary(
            type => type.GetInterfaces()[0].GetGenericArguments()[0],
            type => (IOtherBuildingFactory)Activator.CreateInstance(type, [])!);
    }
}