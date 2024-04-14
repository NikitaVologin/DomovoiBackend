using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;

namespace DomovoiBackend.Application.Services.CounterAgentServices.Interfaces;

/// <summary>
/// Интерфейс сервиса контр-агентов.
/// </summary>
public interface ICounterAgentService
{
    /// <summary>
    /// Добавить контрагента.
    /// </summary>
    /// <param name="request">Запрос на добавление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о контр-агенте</returns>
    Task<CounterAgentInformation> AddAsync(AddCounterAgentRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Логин.
    /// </summary>
    /// <param name="request">Запрос авторизации.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о контр-агенте.</returns>
    Task<CounterAgentInformation> LoginAsync(AuthorizationRequest request, CancellationToken cancellationToken);
}