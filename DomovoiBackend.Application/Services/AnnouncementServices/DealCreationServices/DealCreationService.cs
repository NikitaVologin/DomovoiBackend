using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals;
using DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Abstraction;
using DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices.Interfaces;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Factories.DealsFactories;

namespace DomovoiBackend.Application.Services.AnnouncementServices.DealCreationServices;

public class DealCreationService : IDealCreationService
{
    private readonly IMapper _mapper;

    private static readonly Dictionary<Type, Func<IMapper, IConcreteMapDealService>> ServiceConstructorsDictionary =
        GetRealityServicesDictionaryFromAssembly(Assembly.GetExecutingAssembly());

    public DealCreationService(IMapper mapper) => _mapper = mapper;

    private static Dictionary<Type, Func<IMapper, IConcreteMapDealService>> GetRealityServicesDictionaryFromAssembly(Assembly assembly)
    {
        var services = assembly.GetTypes()
            .Where(type => type.BaseClassesAndInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(ConcreteMapDealServiceBase<,>)))
            .Select(type => (type.BaseType!.GetGenericArguments()[0], type));

        var resultDictionary = new Dictionary<Type, Func<IMapper, IConcreteMapDealService>>();

        foreach (var (infoType, service) in services)
        {
            if(resultDictionary.ContainsKey(infoType)) continue;
            var mapperParameter = Expression.Parameter(typeof(IMapper), "mapper");
            var serviceConstructor = service.GetConstructors().First();
            var constructorExpression = Expression.New(serviceConstructor, mapperParameter);
            var lambda = Expression.Lambda<Func<IMapper, IConcreteMapDealService>>(constructorExpression,
                mapperParameter);
            resultDictionary[infoType] = lambda.Compile();
        }

        return resultDictionary;
    }

    public Deal CreateDeal(DealRequestInfo requestInfo, Guid announcementId)
    {
        
        var service = ServiceConstructorsDictionary[requestInfo.GetType()](_mapper);
        var realityInfo =  service.MapDealInfo(requestInfo);
        return new BaseDealFactory().Generate(realityInfo, announcementId);
    }
}