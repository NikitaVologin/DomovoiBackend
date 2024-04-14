using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Entities.Deals.Rents;

namespace DomovoiBackend.Application.Information.Deals.Rents;

/// <summary>
/// Информация о условиях аренды для запроса/ответа.
/// </summary>
public class RentConditionInformation : IMapTwoSide<RentConditions>
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