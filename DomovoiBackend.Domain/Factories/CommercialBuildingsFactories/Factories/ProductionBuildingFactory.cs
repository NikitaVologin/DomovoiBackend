using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Factories;

public class ProductionBuildingFactory : ICommercialBuildingFactory<ProductionBuildingInfo, Production>
{
    public Production Generate(ProductionBuildingInfo info)
    {
        return new Production
        {
            Id = Guid.NewGuid(),
            FloorsCount = info.FloorsCount,
            Entry = info.Entry,
            Address = info.Address,
            IsUse = info.InUse,
            IsAccess = info.IsAccess,
            Building = info.Building,
            Infrastructure = info.Infrastructure,
            RoomsQuantity = info.RoomsQuantity
        };
    }
}