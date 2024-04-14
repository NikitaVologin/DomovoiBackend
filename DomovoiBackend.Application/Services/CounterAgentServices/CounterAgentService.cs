using AutoMapper;
using DomovoiBackend.Application.Exceptions.Authorization;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Requests.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

namespace DomovoiBackend.Application.Services.CounterAgentServices;

public class CounterAgentService : ICounterAgentService
{
    private readonly ICounterAgentRepository _repository;
    private readonly CounterAgentCreationService _creationService;

    public CounterAgentService(ICounterAgentRepository repository, CounterAgentCreationService creationService)
    {
        _repository = repository;
        _creationService = creationService;
    }

    public async Task<CounterAgentInformation> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken)
    {
        if (await _repository.IsExistAsync(request.Email, cancellationToken))
        {
            throw new UserExistException(request.Email);
        }
        var counterAgent = _creationService.CreateDealFromRequest(request);
        await _repository.AddAsync(counterAgent, cancellationToken);
        return _creationService.CreateInfoFromEntity(counterAgent);
    }

    public async Task<CounterAgentInformation> LoginAsync(AuthorizationRequest request, CancellationToken cancellationToken)
    {
        var counterAgent =
            await _repository.GetCounterAgentByAuthDataAsync(request.Email, request.Password, cancellationToken);
        return _creationService.CreateInfoFromEntity(counterAgent);
    }
}