using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

public interface IDealFactory<in TIn, out TOut> : IDealFactory
    where TIn : BaseDealInfo
    where TOut : Deal
{
    TOut Generate(TIn info, Guid announcementId);

    Deal IDealFactory.Generate(BaseDealInfo info, Guid announcementId)
    {
        if (info is TIn specialInfo)
            return Generate(specialInfo, announcementId);
        throw new ArgumentException();
    }
}

public interface IDealFactory
{
    Deal Generate(BaseDealInfo info, Guid announcementId);
}