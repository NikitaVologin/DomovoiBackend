using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Factories;

public class RoomFactory : ILivingBuildingFactory<RoomInfo, Room>
{
    public Room Generate(RoomInfo info)
    {
        return new Room
        {
            Area = info.Area,
            Type = info.Type,
            Floor = info.Floor,
            NeighboursCount = info.NeighboursCount,
            Flat = info.Flat
        };
    }
}