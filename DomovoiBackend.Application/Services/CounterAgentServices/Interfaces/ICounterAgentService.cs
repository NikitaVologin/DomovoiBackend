using DomovoiBackend.Application.Models.CounterAgents;

namespace DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

public interface ICounterAgentService
{
    Task<Guid> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken);
}