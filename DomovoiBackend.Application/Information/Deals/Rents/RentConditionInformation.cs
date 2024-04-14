using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction;
using DomovoiBackend.Domain.Factories.DealsFactories.Infos.RentInfos;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о условиях аренды для запроса/ответа.
/// </summary>
public class RentConditionInformation : IMapTo<RentConditionInfo>, IMapFrom<RentConditions>
{
    /// <summary>
    /// Величина платежа.
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Период платежа.
    /// </summary>
    public string? Period { get; set; }
    
    /// <summary>
    /// Сумма депозита.
    /// </summary>
    public double Deposit { get; set; }
    
    /// <summary>
    /// Сумма комунальных платежей.
    /// </summary>
    public double CommunalPays { get; set; }
    
    /// <summary>
    /// Предоплата.
    /// </summary>
    public double Prepay { get; set; }
}