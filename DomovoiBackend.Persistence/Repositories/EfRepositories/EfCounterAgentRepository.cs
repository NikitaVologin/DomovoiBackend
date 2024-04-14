using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Persistence.EfSettings;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Repositories.EfRepositories;

public class EfCounterAgentRepository : ICounterAgentRepository
{
    private readonly DomovoiContext _context;

    public EfCounterAgentRepository(DomovoiContext context) => _context = context;
    
    public async Task<Guid> AddAsync(CounterAgent counterAgent, CancellationToken cancellationToken)
    {
        await _context.CounterAgents.AddAsync(counterAgent, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return counterAgent.Id;
    }

    public async Task<CounterAgent> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var counterAgent = await _context.CounterAgents.FirstOrDefaultAsync(
            counterAgent => counterAgent.Id == id, cancellationToken);

        if (counterAgent == null) throw new DbNotFoundException(typeof(CounterAgent), id);
        
        return counterAgent;
    }

    public async Task<bool> IsExistAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.CounterAgents.AnyAsync(counterAgent => counterAgent.Email == email,
            cancellationToken);
    }

    public async Task<CounterAgent> GetCounterAgentByAuthDataAsync(string email, string password, CancellationToken cancellationToken)
    {
        var counterAgent = await _context.CounterAgents.FirstOrDefaultAsync(
            counterAgent => counterAgent.Email == email && counterAgent.Password == password,
            cancellationToken);

        if (counterAgent == null)
            throw new DbNotFoundException(typeof(CounterAgent), new
            {
                Email = email,
                Password = password
            });

        return counterAgent;
    }
}