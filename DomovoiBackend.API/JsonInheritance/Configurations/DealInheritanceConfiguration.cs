using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Deals.Sells;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class DealInheritanceConfiguration : JsonInheritanceConfiguration<DealInformation>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(SellInformation), DealStringLiteral.Sell },
        { typeof(RentInformation), DealStringLiteral.Rent }
    };
}