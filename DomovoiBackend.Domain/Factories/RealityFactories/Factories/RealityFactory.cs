using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;
using DomovoiBackend.Domain.Factories.RealityFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.RealityFactories.Factories;

public class RealityFactory : IRealityFactory
{
    private static readonly Dictionary<Type, Func<BaseRealityInfo, Reality>> GeneratorsDictionary = new()
    {
        { typeof(BaseCommercialBuildingInfo), info => new BaseCommercialFactory().Generate((BaseCommercialBuildingInfo)info)  },
    //    { typeof(BaseLivingBuildingInfo), info => new BaseLivingBuildingFactory().Generate((BaseLivingBuildingInfo)info) },
    //    { typeof(BaseOtherBuildingInfo), info => new BaseOtherBuildingFactory().Generate((BaseOtherBuildingInfo)info)}
    };
    
    public Reality GenerateReality(BaseRealityInfo info, Guid announcementId)
    {
        var baseType = info.GetType().BaseType;
        if (baseType == null) throw new ArgumentException();
        var reality = GeneratorsDictionary[baseType](info);
        reality.Id = announcementId;
        return reality;
    }
}