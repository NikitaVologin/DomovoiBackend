using DomovoiBackend.Application.Mapping.Interfaces;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;

public class RealityRequestInfo
{
    public double Area { get; set; }
    public string Type { get; set; } = null!;
}