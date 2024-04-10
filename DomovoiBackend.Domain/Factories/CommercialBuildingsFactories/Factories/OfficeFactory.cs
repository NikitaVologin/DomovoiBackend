using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Factories;

public class OfficeFactory : ICommercialBuildingFactory<OfficeBuildingInfo, Office>
{
    public Office Generate(OfficeBuildingInfo info)
    {
        return new Office
        {
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
}