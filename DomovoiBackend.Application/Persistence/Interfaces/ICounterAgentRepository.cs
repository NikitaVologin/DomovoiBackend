using DomovoiBackend.Domain.Entities.CounterAgents;

namespace DomovoiBackend.Application.Persistence.Interfaces;

public interface ICounterAgentRepository
{
    Task<Guid> AddAsync(CounterAgent counterAgent, CancellationToken cancellationToken);
    Task<CounterAgent> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<CounterAgent> GetCounterAgentByAuthDataAsync(string email, string password, CancellationToken cancellationToken);
}