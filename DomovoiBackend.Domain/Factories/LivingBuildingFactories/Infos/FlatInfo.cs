using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.LivingBuildingFactories.Infos;

public record FlatInfo(
    double Area,
    string Type,
    int Floor,
    bool IsFresh,
    int RoomsCount,
    bool IsRepaired,
    double KitchenArea,
    string BalconyType,
    string ViewFromBalcony,
    ApartmentHouse ApartmentHouse) : BaseLivingBuildingInfo(Area, Type, Floor);