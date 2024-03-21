using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Factories;

public class OfficeFactory : ICommercialBuildingFactory<OfficeBuildingInfo, Office>, 
    ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>
{
    public Office Generate(OfficeBuildingInfo info)
    {
        return new Office
        {
            Id = Guid.NewGuid(),
            FloorsCount = info.FloorsCount,
            Entry = info.Entry,
            Address = info.Address,
            IsUse = info.InUse,
            IsAccess = info.IsAccess,
            Building = info.Building,
            Name = info.Name,
            RoomsCount = info.RoomsCount
        };
    }

    CommercialBuilding ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>.Generate(
        BaseCommercialBuildingInfo info)
    {
        if (info is OfficeBuildingInfo officeInfo)
            return Generate(officeInfo); 
        throw new ArgumentException($"{info} not office building");
    }
}