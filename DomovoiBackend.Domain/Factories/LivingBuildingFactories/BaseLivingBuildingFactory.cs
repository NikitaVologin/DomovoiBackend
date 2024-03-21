using System.Reflection;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories;

public class BaseLivingBuildingFactory : ILivingBuildingFactory
{
    private static readonly Dictionary<Type, ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>>
        CurrentFactories = GetLivingBuildingFactory(Assembly.GetExecutingAssembly());
    
    
    public LivingBuilding Generate(BaseLivingBuildingInfo info) =>
        CurrentFactories[info.GetType()].Generate(info);

    private static Dictionary<Type, ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>> GetLivingBuildingFactory(Assembly assembly)
    {
        var factoryTypes = assembly
            .GetTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType &&
                                                         i.GetGenericTypeDefinition() ==
                                                         typeof(ILivingBuildingFactory<,>)));
        return factoryTypes.ToDictionary(
            type => type.GetInterfaces()[0].GetGenericArguments()[0],
            type => (ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>)Activator.CreateInstance(type, [])!);
    }
}