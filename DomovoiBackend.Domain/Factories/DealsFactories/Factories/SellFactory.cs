using DomovoiBackend.Domain.Entities.Deals.Sells;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;
using DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Factories;

public class SellFactory : IDealFactory<SellInfo, Sell>
{
    public Sell Generate(SellInfo info, Guid announcementId)
    {
        var sellConditions = info.SellConditions;
        var sellFeatures = info.SellFeatures;

        return new Sell
        {
            Id = announcementId,
            SellConditions = new SellConditions()
            {
                Id = announcementId,
                Price = sellConditions.Price,
                Type = sellConditions.Type
            },
            SellFeatures = new SellFeatures
            {
                Id = announcementId,
                HaveChildPrescribers = sellFeatures.HaveChildPrescribers,
                HaveChildOwners = sellFeatures.HaveChildOwners,
                OwnersCount = sellFeatures.OwnersCount,
                PrescribersCount = sellFeatures.PrescribersCount,
                YearInOwn = sellFeatures.YearInOwn
            }
        };
    }
}