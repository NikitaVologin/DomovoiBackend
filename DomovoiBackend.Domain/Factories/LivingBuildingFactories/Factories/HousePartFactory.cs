using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Factories;

public class HousePartFactory : ILivingBuildingFactory<HousePartInfo, HousePart>,
    ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>
{
    public HousePart Generate(HousePartInfo info)
    {
        return new HousePart
        {
            Id = Guid.NewGuid(),
            Area = info.Area,
            Type = info.Type,
            Floor = info.Floor,
            Part = info.Part,
            House = info.House
        };
    }

    LivingBuilding ILivingBuildingFactory<BaseLivingBuildingInfo, LivingBuilding>.Generate(BaseLivingBuildingInfo info)
    {
        if (info is HousePartInfo housePartInfo)
            return Generate(housePartInfo);
        throw new ArgumentException();
    }
}