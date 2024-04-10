using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;
using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Factories.CounterAgentFactories;

namespace DomovoiBackend.Application.Services.CounterAgentServices.CreationServices;

public class CounterAgentCreationService : ICounterAgentCreationService
{
    private readonly IMapper _mapper;

    private readonly Dictionary<Type, Func<IMapper, IConcreteMapCounterAgentService>> _serviceConstructorsDictionary =
        GetRealityServicesDictionaryFromAssembly(Assembly.GetExecutingAssembly());

    public CounterAgentCreationService(IMapper mapper) => _mapper = mapper;
    
    public CounterAgent CreateCounterAgent(CounterAgentRequestInfo requestInfo)
    {
        var service = _serviceConstructorsDictionary[requestInfo.GetType()](_mapper);
        var realityInfo =  service.CreateCounterAgent(requestInfo);
        return new BaseCounterAgentFactory().Generate(realityInfo);
    }

    private static Dictionary<Type, Func<IMapper, IConcreteMapCounterAgentService>> GetRealityServicesDictionaryFromAssembly(Assembly assembly)
    {
        var services = assembly.GetTypes()
            .Where(type => type.BaseClassesAndInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(ConcreteMapCounterAgentServiceBase<,>)))
            .Select(type => (type.BaseType!.GetGenericArguments()[0], type));

        var resultDictionary = new Dictionary<Type, Func<IMapper, IConcreteMapCounterAgentService>>();

        foreach (var (infoType, service) in services)
        {
            if(resultDictionary.ContainsKey(infoType)) continue;
            var mapperParameter = Expression.Parameter(typeof(IMapper), "mapper");
            var serviceConstructor = service.GetConstructors().First();
            var constructorExpression = Expression.New(serviceConstructor, mapperParameter);
            var lambda = Expression.Lambda<Func<IMapper, IConcreteMapCounterAgentService>>(constructorExpression,
                mapperParameter);
            resultDictionary[infoType] = lambda.Compile();
        }

        return resultDictionary;
    }
}