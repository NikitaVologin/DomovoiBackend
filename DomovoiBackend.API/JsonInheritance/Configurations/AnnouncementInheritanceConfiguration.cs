using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.JsonInheritance.Abstraction;
using DomovoiBackend.Application.Information.Realities;
using DomovoiBackend.Application.Information.Realities.Commercial;
using DomovoiBackend.Application.Information.Realities.Living;

namespace DomovoiBackend.API.JsonInheritance.Configurations;

public class AnnouncementInheritanceConfiguration : JsonInheritanceConfiguration<RealityInformation>
{
    protected override Dictionary<Type, string> Subtypes { get; set; } = new()
    {
        { typeof(OfficeInformation), RealityStringLiteral.Office },
        { typeof(FlatInformation), RealityStringLiteral.Flat }
    };
}
