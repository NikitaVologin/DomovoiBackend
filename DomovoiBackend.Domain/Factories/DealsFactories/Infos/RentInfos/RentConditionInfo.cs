namespace DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

public record RentConditionInfo(
    double Price,
    string Period,
    double Deposit,
    double CommunalPays,
    double Prepay);