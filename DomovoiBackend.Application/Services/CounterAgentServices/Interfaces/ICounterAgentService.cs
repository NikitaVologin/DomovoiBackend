using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;

namespace DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

public interface ICounterAgentService
{
    Task<CounterAgentInformation> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken);
    Task<CounterAgentInformation> LoginAsync(AuthorizationRequest request, CancellationToken cancellationToken);
}