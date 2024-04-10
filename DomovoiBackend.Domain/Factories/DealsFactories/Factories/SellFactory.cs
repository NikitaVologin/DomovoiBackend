using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell;
using DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell.Addiction;
using DomovoiBackend.Domain.Entities.Deals.Types.Sell;
using DomovoiBackend.Domain.Entities.Deals.Types.Sell.Addiction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;
using DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Factories;

public class SellFactory : IDealFactory<SellInfo, Sell>
{
    public Sell Generate(SellInfo info, Guid announcementId)
    {
        var sellConditions = info.SellConditionInfo;
        var sellFeatures = info.SellFeaturesInfo;

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