namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.SellInfos;

public record SellFeaturesInfo(
    int YearInOwn,
    int OwnersCount,
    int PrescribersCount,
    bool HaveChildOwners,
    bool HaveChildPrescribers);