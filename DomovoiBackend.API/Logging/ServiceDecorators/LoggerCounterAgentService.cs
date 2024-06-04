using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;
using DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

namespace DomovoiBackend.API.Logging.ServiceDecorators;

public class LoggerCounterAgentService : ICounterAgentService
{
    private readonly ICounterAgentService _service;
    private readonly ILogger<ICounterAgentService> _logger;

    public LoggerCounterAgentService(ICounterAgentService service, ILogger<ICounterAgentService> logger) =>
        (_service, _logger) = (service, logger);
    
    public async Task<CounterAgentInformation> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.AddAsync(request, cancellationToken);
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@information} добавлен", information);
            return information;
        }
        catch (Exception exception)
        {
            _logger.LogError("[COUNTER_AGENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<CounterAgentInformation> LoginAsync(AuthorizationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.LoginAsync(request, cancellationToken);
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@information} залогинился", information);
            return information;
        }
        catch (Exception exception)
        {
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task UpdateAsync(Guid id, CounterAgentUpdateRequest information, CancellationToken cancellationToken)
    {
        try
        {
            await _service.UpdateAsync(id, information, cancellationToken);
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@information} обновлён", information);
        }
        catch (Exception exception)
        {
            _logger.LogError("[COUNTER_AGENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _service.RemoveAsync(id, cancellationToken);
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@id} удалён", id);
        }
        catch (Exception exception)
        {
            _logger.LogError("[COUNTER_AGENT_SERVICE] {@error}", exception);
            throw;
        }
    }

    public async Task<CounterAgentInformation> GetCounterAgentInfoAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var information = await _service.GetCounterAgentInfoAsync(id, cancellationToken);
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@information} получен", information);
            return information;
        }
        catch (Exception exception)
        {
            _logger.LogInformation("[COUNTER_AGENT_SERVICE] {@error}", exception);
            throw;
        }
    }
}