using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Factories;

public class HouseFactory : ILivingBuildingFactory<HouseInfo, House>,
    ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>
{
    public House Generate(HouseInfo info)
    {
        return new House
        {
            Id = Guid.NewGuid(),
            Area = info.Area,
            Type = info.Type,
            Floor = info.Floor,
            BuildYear = info.BuildYear,
            RoomsCount = info.RoomsCount,
            FloorsCount = info.FloorsCount,
            IsRenovated = info.IsRenovated,
            IsHeating = info.IsHeating,
            IsAccess = info.IsAccess,
            IsInfrastructure = info.IsInfrastructure,
            IsLandscaping = info.IsLandscaping,
            Bathroom = info.Bathroom,
            HouseArea = info.HouseArea
        };
    }
    
    LivingBuilding ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>.Generate(BaseLivingBuildingInfo info)
    {
        if (info is HouseInfo houseInfo)
            return Generate(houseInfo);
        throw new ArgumentException();
    }
}