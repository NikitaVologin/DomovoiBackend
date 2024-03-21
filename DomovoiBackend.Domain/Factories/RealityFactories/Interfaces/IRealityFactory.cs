using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Factories.RealityFactories.Abstraction;

namespace DomovoiBackend.Domain.Factories.RealityFactories.Interfaces;

public interface IRealityFactory
{
    Reality GenerateReality(BaseRealityInfo info);
}