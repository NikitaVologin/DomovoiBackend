using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Rent;
using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Rent.Addiction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;
using DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Factories;

public class RentFactory : IDealFactory<RentInfo, Rent>
{
    public Rent Generate(RentInfo info)
    {
        var guid = Guid.NewGuid();
        var rentConditions = info.ConditionInfo;
        var rentRules = info.RulesInfo;

        return new Rent
        {
            Id = guid,
            RentConditions = new RentConditions
            {
                Id = guid,
                CommunalPays = rentConditions.CommunalPays,
                Deposit = rentConditions.Deposit,
                Period = rentConditions.Period,
                Prepay = rentConditions.Prepay,
                Price = rentConditions.Price
            },
            RentRules = new RentRules
            {
                Id = guid,
                CanSmoke = rentRules.CanSmoke,
                Facilities = rentRules.Facilities,
                WithAnimals = rentRules.WithAnimals,
                WithKids = rentRules.WithKids
            }
        };
    }
}