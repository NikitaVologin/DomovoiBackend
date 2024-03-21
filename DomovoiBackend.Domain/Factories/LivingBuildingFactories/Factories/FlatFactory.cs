using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Factories;

public class FlatFactory : ILivingBuildingFactory<FlatInfo, Flat>
{
    public Flat Generate(FlatInfo info)
    {
        return new Flat
        {
            Id = Guid.NewGuid(),
            Area = info.Area,
            Type = info.Type,
            Floor = info.Floor,
            IsFresh = info.IsFresh,
            RoomsCount = info.RoomsCount,
            IsRepaired = info.IsRepaired,
            KitchenArea = info.KitchenArea,
            BalconyType = info.BalconyType,
            ViewFromBalcony = info.ViewFromBalcony,
            ApartmentHouse = info.ApartmentHouse
        };
    }
}