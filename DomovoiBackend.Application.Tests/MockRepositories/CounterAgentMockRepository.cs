using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Tests.MockRepositories;

public class CounterAgentMockRepository : ICounterAgentRepository
{
    private readonly List<CounterAgent> _mockData =
    [
        new PhysicalCounterAgent()
        {
            ContactNumber = "123",
            Email = "123@mail.ru",
            FIO = "Alla Pugachevo Zhest",
            Id = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
            Password = "123"
        },
        
        new LegalCounterAgent()
        {
            ContactNumber = "244",
            Email = "12345@mail.ru",
            Id = Guid.Parse("7aedf545-068d-426e-bc3a-750b9926b69b"),
            Name = "Cool Company",
            Password = "123",
            Tin = "12456",
        }
    ];
    
    public Task<Guid> AddAsync(CounterAgent counterAgent, CancellationToken cancellationToken)
    {
        if (counterAgent.Id == default)
        {
            var counterAgentId = Guid.NewGuid();
            counterAgent.Id = counterAgentId;
        }
        _mockData.Add(counterAgent);
        return Task.FromResult(counterAgent.Id);
    }

    public Task<CounterAgent> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var counterAgent = _mockData.FirstOrDefault(c => c.Id == id);
        if (counterAgent == default) throw new DbNotFoundException(typeof(CounterAgent), id);
        return Task.FromResult(counterAgent);
    }

    public Task<CounterAgent> GetCounterAgentByAuthDataAsync(string email, string password, CancellationToken cancellationToken)
    {
        var counterAgent = _mockData.FirstOrDefault(c => c.Email == email && c.Password == password);
        if (counterAgent == default) throw new DbNotFoundException(typeof(CounterAgent), email);
        return Task.FromResult(counterAgent);
    }

    public Task<bool> IsExistAsync(string email, CancellationToken cancellationToken)
    {
        return Task.FromResult(_mockData.Exists(c => c.Email == email));
    }

    public Task UpdateCounterAgentAsync(CounterAgent counterAgent, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveCounterAgentAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CounterAgent> GetCounterAgentAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}