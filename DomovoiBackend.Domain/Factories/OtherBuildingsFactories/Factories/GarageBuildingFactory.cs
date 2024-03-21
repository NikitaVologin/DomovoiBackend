using DomovoiBackend.Domain.Entities.Realities.Garages;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.OtherBuildingsFactories.Factories;

public class GarageBuildingFactory : IOtherBuildingFactory<GarageBuildingInfo, Garage>
{
    public Garage Generate(GarageBuildingInfo info)
    {
        return new Garage
        {
            Id = Guid.NewGuid(),
            Area = info.Area,
            Type = info.Type,
            State = info.State,
            GKSName = info.GKSName,
            Access = info.Access,
            Security = info.Security,
            Electricity = info.Electricity,
            Heating = info.Heating,
            WaterSupply = info.WaterSupply,
            Infrastructure = info.Infrastructure
        };
    }
}