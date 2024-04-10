using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Factories;

public class WarehouseFactory : ICommercialBuildingFactory<WarehouseBuildingInfo, Warehouse>
{
    public Warehouse Generate(WarehouseBuildingInfo info)
    {
        return new Warehouse
        {
            FloorsCount = info.FloorsCount,
            Entry = info.Entry,
            Address = info.Address,
            IsUse = info.InUse,
            IsAccess = info.IsAccess,
            Building = info.Building,
            Infrastructure = info.Infrastructure
        };
    }
}