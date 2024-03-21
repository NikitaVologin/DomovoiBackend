using System.Reflection;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CounterAgentFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CounterAgentFactories;

public class BaseCounterAgentFactory : ICounterAgentFactory
{
    private static readonly Dictionary<Type, ICounterAgentFactory> 
        CurrentFactories = GetCounterAgentFactory(Assembly.GetExecutingAssembly());
    
    
    public CounterAgent Generate(BaseCounterAgentInfo info) =>
        CurrentFactories[info.GetType()].Generate(info);

    private static Dictionary<Type, ICounterAgentFactory> GetCounterAgentFactory(Assembly assembly)
    {
        var factoryTypes = assembly
            .GetTypes()
            .Where(type => type.GetInterfaces().Any(i => i.IsGenericType &&
                                                         i.GetGenericTypeDefinition() ==
                                                         typeof(ICounterAgentFactory<,>)));
        return factoryTypes.ToDictionary(
            type => type.GetInterfaces()[0].GetGenericArguments()[0],
            type => (ICounterAgentFactory)Activator.CreateInstance(type, [])!);
    }
}