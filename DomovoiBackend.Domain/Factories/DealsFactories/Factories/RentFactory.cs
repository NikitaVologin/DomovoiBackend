using DomovoiBackend.Domain.Entities.Deals.Types.Rent;
using DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;
using DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Factories;

public class RentFactory : IDealFactory<RentInfo, Rent>
{
    public Rent Generate(RentInfo info, Guid announcementId)
    {
        var rentConditions = info.RentConditionInfo;
        var rentRules = info.RentRulesInfo;

        return new Rent
        {
            Id = announcementId,
            RentConditions = new RentConditions
            {
                Id = announcementId,
                CommunalPays = rentConditions.CommunalPays,
                Deposit = rentConditions.Deposit,
                Period = rentConditions.Period,
                Prepay = rentConditions.Prepay,
                Price = rentConditions.Price
            },
            RentRules = new RentRules
            {
                Id = announcementId,
                CanSmoke = rentRules.CanSmoke,
                Facilities = rentRules.Facilities,
                WithAnimals = rentRules.WithAnimals,
                WithKids = rentRules.WithKids
            }
        };
    }
}