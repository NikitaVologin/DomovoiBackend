using DomovoiBackend.Domain.Entities.CounterAgents;

namespace DomovoiBackend.Application.Persistence.Interfaces;

/// <summary>
/// Интерфейс репозитория контр-агентов.
/// </summary>
public interface ICounterAgentRepository
{
    /// <summary>
    /// Добавить контр-агента.
    /// </summary>
    /// <param name="counterAgent">Контр-агент</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Id контр-агента.</returns>
    Task<Guid> AddAsync(CounterAgent counterAgent, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить контр-агента по Id.
    /// </summary>
    /// <param name="id">Id контр-агента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Контр-агент.</returns>
    Task<CounterAgent> GetAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить контр-агента по авторизационным данным.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Контр-агент.</returns>
    Task<CounterAgent> GetCounterAgentByAuthDataAsync(string email, string password, CancellationToken cancellationToken);
    
    /// <summary>
    /// Существует ли контр-агент с данным Email.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Истина - существует, Ложь - не существует.</returns>
    Task<bool> IsExistAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить контр-агента.
    /// </summary>
    /// <param name="counterAgent">Обновлённый контр-агент.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пустой вызов.</returns>
    Task UpdateCounterAgentAsync(CounterAgent counterAgent, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить контр-агента по ID;
    /// </summary>
    /// <param name="id">Id объект.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пустой вызов.</returns>
    Task RemoveCounterAgentAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить контр-агента по ID;
    /// </summary>
    /// <param name="id">GUID контр-агента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Контр-агент.</returns>
    Task<CounterAgent> GetCounterAgentAsync(Guid id, CancellationToken cancellationToken);
}