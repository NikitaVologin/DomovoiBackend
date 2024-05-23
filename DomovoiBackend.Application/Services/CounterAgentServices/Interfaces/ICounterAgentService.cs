using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests.Base;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Requests.CounterAgents.UpdateRequests;

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

    /// <summary>
    /// Обновить контр-агента.
    /// </summary>
    /// <param name="id">Guid контр-агента.</param>
    /// <param name="information">Информация об контр-агенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Таска.</returns>
    Task UpdateAsync(Guid id, CounterAgentUpdateRequest information, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить контр-агента.
    /// </summary>
    /// <param name="id">Guid контр-агента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Таска.</returns>
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
}