using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Factories;

public class WarehouseFactory : ICommercialBuildingFactory<WarehouseBuildingInfo, Warehouse>,
    ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>
{
    public Warehouse Generate(WarehouseBuildingInfo info)
    {
        return new Warehouse
        {
            Id = Guid.NewGuid(),
            FloorsCount = info.FloorsCount,
            Entry = info.Entry,
            Address = info.Address,
            IsUse = info.InUse,
            IsAccess = info.IsAccess,
            Building = info.Building,
            Infrastructure = info.Infrastructure
        };
    }

    CommercialBuilding ICommercialBuildingFactory<BaseCommercialBuildingInfo, CommercialBuilding>.Generate(
        BaseCommercialBuildingInfo info)
    {
        if (info is WarehouseBuildingInfo warehouseInfo)
            return Generate(warehouseInfo); 
        throw new ArgumentException($"{info} not warehouse building");
    }
    
    
}