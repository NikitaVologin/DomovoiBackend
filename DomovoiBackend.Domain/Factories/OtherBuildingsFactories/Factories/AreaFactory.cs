using DomovoiBackend.Domain.Entities.Realities.Areas;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Factories;

public class AreaFactory : IOtherBuildingFactory<AreaInfo, Area>
{
    public Area Generate(AreaInfo info)
    {
        return new Area
        {
            Id = Guid.NewGuid(),
            Area = info.Area,
            Type = info.Type,
            Electricity = info.Electricity,
            WaterSupply = info.WaterSupply,
            Gas = info.Gas,
            Sewage = info.Sewage
        };
    }
}