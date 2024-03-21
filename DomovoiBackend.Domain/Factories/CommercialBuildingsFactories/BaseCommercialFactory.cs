using System.Reflection;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories;

public class BaseCommercialFactory : ICommercialBuildingFactory
{
    public static readonly Dictionary<Type, ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>>
        CurrentFactories = GetCommercialFactories(Assembly.GetExecutingAssembly());

    public CommercialBuilding Generate(BaseCommercialBuildingInfo info) =>
        CurrentFactories[info.GetType()].Generate(info);

    private static Dictionary<Type, ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>> GetCommercialFactories(Assembly assembly)
    {
        var factoryTypes = assembly
            .GetTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType &&
                                                         i.GetGenericTypeDefinition() ==
                                                         typeof(ICommercialBuildingFactory<,>)));
        return factoryTypes.ToDictionary(
            type => type.GetInterfaces()[0].GetGenericArguments()[0],
            type => (ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>)Activator.CreateInstance(type, [])!);
    }
}