using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;

namespace DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

public interface ICounterAgentService
{
    Task<Guid> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken);

    Task<CounterAgentInformation> GetCounterAgentInfoByAuthorizationData(AuthorizationRequest request, CancellationToken cancellationToken);
}