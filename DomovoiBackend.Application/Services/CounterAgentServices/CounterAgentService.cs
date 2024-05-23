using DomovoiBackend.Application.Exceptions.Authorization;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using DomovoiBackend.Application.Services.MappingServices.Interfaces;

namespace DomovoiBackend.Application.Services.CounterAgentServices;

/// <summary>
/// Сервис контр-агентов.
/// </summary>
public class CounterAgentService : ICounterAgentService
{
    /// <summary>
    /// Репозиторий контр-агентов.
    /// </summary>
    private readonly ICounterAgentRepository _repository;
    
    /// <summary>
    /// Сервис отображений контр-агентов.
    /// </summary>
    private readonly ICounterAgentMappingService _mappingService;

    public CounterAgentService(ICounterAgentRepository repository, ICounterAgentMappingService mappingService)
    {
        _repository = repository;
        _mappingService = mappingService;
    }

    public async Task<CounterAgentInformation> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken)
    {
        if (await _repository.IsExistAsync(request.Email, cancellationToken))
        {
            throw new UserExistException(request.Email);
        }
        var counterAgent = _mappingService.MapEntityFromRequest(request);
        await _repository.AddAsync(counterAgent, cancellationToken);
        return _mappingService.MapInformationFromEntity(counterAgent);
    }

    public async Task<CounterAgentInformation> LoginAsync(AuthorizationRequest request, CancellationToken cancellationToken)
    {
        var counterAgent =
            await _repository.GetCounterAgentByAuthDataAsync(request.Email, request.Password, cancellationToken);
        return _mappingService.MapInformationFromEntity(counterAgent);
    }

    public async Task UpdateAsync(Guid id, CounterAgentUpdateRequest information, CancellationToken cancellationToken)
    {
        var counterAgent = _mappingService.MapEntityFromRequest(information);
        counterAgent.Id = id;
        await _repository.UpdateCounterAgentAsync(counterAgent, cancellationToken);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken) =>
        await _repository.RemoveCounterAgentAsync(id, cancellationToken);
}