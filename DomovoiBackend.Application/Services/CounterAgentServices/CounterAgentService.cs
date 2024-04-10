using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

namespace DomovoiBackend.Application.Services.CounterAgentServices;

public class CounterAgentService : ICounterAgentService
{
    private readonly ICounterAgentRepository _repository;
    private readonly ICounterAgentCreationService _creationService;

    public CounterAgentService(ICounterAgentRepository repository,
        ICounterAgentCreationService creationService) => 
        (_repository, _creationService) = (repository, creationService);
    
    public async Task<Guid> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken)
    {
        var counterAgent = _creationService.CreateCounterAgent(request.CounterAgentInfo);
        await _repository.AddAsync(counterAgent, cancellationToken);
        return counterAgent.Id;
    }
}