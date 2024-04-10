using AutoMapper;
using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos;
using DomovoiBackend.Application.Models.CounterAgents.RequestInfos.Base;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices.CreationServices.Interfaces;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;

namespace DomovoiBackend.Application.Services.CounterAgentServices;

public class CounterAgentService : ICounterAgentService
{
    private readonly ICounterAgentRepository _repository;
    private readonly ICounterAgentCreationService _creationService;
    private readonly IMapper _mapper;

    public CounterAgentService(ICounterAgentRepository repository,
        ICounterAgentCreationService creationService,
        IMapper mapper)
    {
        _repository = repository;
        _creationService = creationService;
        _mapper = mapper;
    }
    
    public async Task<Guid> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken)
    {
        var counterAgent = _creationService.CreateCounterAgent(request.CounterAgentInfo);
        await _repository.AddAsync(counterAgent, cancellationToken);
        return counterAgent.Id;
    }

    public async Task<CounterAgentInformation> GetCounterAgentInfoByAuthorizationData(AuthorizationRequest request,
        CancellationToken cancellationToken)
    {
        var email = request.Email;
        var password = request.Password;
        var counterAgent = await _repository.GetCounterAgentByAuthDataAsync(email, password, cancellationToken);
        if(counterAgent is PhysicalCounterAgent)
            return _mapper.Map<PhysicalCounterAgentInformation>(counterAgent);
        return _mapper.Map<LegalCounterAgentInformation>(counterAgent);
    }
}