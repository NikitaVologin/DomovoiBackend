using DomovoiBackend.Domain.Entities.Announcements.Deals;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.Abstraction;

namespace DomovoiBackend.Domain.Factories.DealsFactories.Interfaces;

public interface IDealFactory<in TIn, out TOut> : IDealFactory
    where TIn : BaseDealInfo
    where TOut : Deal
{
    TOut Generate(TIn info);

    Deal IDealFactory.Generate(BaseDealInfo info)
    {
        if (info is TIn specialInfo)
            return Generate(specialInfo);
        throw new ArgumentException();
    }
}

public interface IDealFactory
{
    Deal Generate(BaseDealInfo info);
}