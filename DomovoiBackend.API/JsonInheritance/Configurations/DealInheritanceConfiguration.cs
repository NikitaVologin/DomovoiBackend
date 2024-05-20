using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Deals.Sells;
using DomovoiBackend.Domain.Entities.Deals;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class DealInheritanceConfiguration : JsonInheritanceConfiguration<Deal>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(SellInformation), "Sell" },
        { typeof(RentInformation), "Rent" }
    };
}