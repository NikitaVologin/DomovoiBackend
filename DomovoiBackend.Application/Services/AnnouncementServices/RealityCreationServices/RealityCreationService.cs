using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;
using DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Abstraction;
using DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices.Interfaces;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Factories.RealityFactories.Factories;

namespace DomovoiBackend.Application.Services.AnnouncementServices.RealityCreationServices;

public class RealityCreationService : IRealityCreationService
{
    private readonly IMapper _mapper;

    private static readonly Dictionary<Type, Func<IMapper, IConcreteMapRealityService>> ServiceConstructorsDictionary =
        GetRealityServicesDictionaryFromAssembly(Assembly.GetExecutingAssembly());

    public RealityCreationService(IMapper mapper) => _mapper = mapper;
    
    public Reality CreateReality(RealityRequestInfo request, Guid announcementId)
    {
        var service = ServiceConstructorsDictionary[request.GetType()](_mapper);
        var realityInfo =  service.MapReality(request);
        return new RealityFactory().GenerateReality(realityInfo, announcementId);
    }

    private static Dictionary<Type, Func<IMapper, IConcreteMapRealityService>> GetRealityServicesDictionaryFromAssembly(Assembly assembly)
    {
        var services = assembly.GetTypes()
            .Where(type => type.BaseClassesAndInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(ConcreteMapRealityServiceBase<,>)))
            .Select(type => (type.BaseType!.GetGenericArguments()[0], type));

        var resultDictionary = new Dictionary<Type, Func<IMapper, IConcreteMapRealityService>>();

        foreach (var (infoType, service) in services)
        {
            if(resultDictionary.ContainsKey(infoType)) continue;
            var mapperParameter = Expression.Parameter(typeof(IMapper), "mapper");
            var serviceConstructor = service.GetConstructors().First();
            var constructorExpression = Expression.New(serviceConstructor, mapperParameter);
            var lambda = Expression.Lambda<Func<IMapper, IConcreteMapRealityService>>(constructorExpression,
                mapperParameter);
            resultDictionary[infoType] = lambda.Compile();
        }

        return resultDictionary;
    }
}