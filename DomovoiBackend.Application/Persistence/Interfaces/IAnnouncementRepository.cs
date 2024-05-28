using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Domain.Entities.Announcements;

namespace DomovoiBackend.Application.Persistence.Interfaces;

/// <summary>
/// Интерфейс репозитория объявлений.
/// </summary>
public interface IAnnouncementRepository
{
    /// <summary>
    /// Добавить объявление.
    /// </summary>
    /// <param name="announcement">Объявление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Id объявления.</returns>
    Task<Guid> AddAnnouncementAsync(Announcement announcement, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить объявление по Id.
    /// </summary>
    /// <param name="id">Id объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объявления.</returns>
    Task<Announcement> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken);

    // TODO: УДАЛИТЬ - УСТАРЕЛО
    /// <summary>
    /// Получить первые I объявлений.
    /// </summary>
    /// <param name="count">Количество объвялений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список объявлений.</returns>
    Task<IList<Announcement>> GetAnnouncementsAsync(int count, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить все объявления;
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IList<Announcement>> GetAnnouncementsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить все объявления пользователя;
    /// </summary>
    /// <param name="userId">Guid пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IList<Announcement>> GetAnnouncementsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить первые toIndex объявлений.
    /// </summary>
    /// <param name="toIndex">Индекс ДО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IList<Announcement>> GetLimitedAnnouncementsAsync(int toIndex, CancellationToken cancellationToken);


    /// <summary>
    /// Получить объявление с fromIndex до toIndex;
    /// </summary>
    /// <param name="fromIndex">Индекс ОТ.</param>
    /// <param name="toIndex">Индекс ДО.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<IList<Announcement>> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex, CancellationToken cancellationToken);

    Task<IList<Announcement>> GetAnnouncementsByParametersAsync(FilterParameters filterParameters, CancellationToken cancellationToken);


    /// <summary>
    /// Удалить объявления.
    /// </summary>
    /// <param name="counterAgentId">Guid контр-агента.</param>
    /// <param name="announcementId">Guid объявления.</param>
    /// <param name="cancellationToken">Токен отмена.</param>
    /// <returns>Таска</returns>
    Task RemoveAnnouncementAsync(Guid counterAgentId, Guid announcementId, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить объявления.
    /// </summary>
    /// <param name="announcementId">Guid объявления.</param>
    /// <param name="announcement">Объвление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Таска.</returns>
    Task UpdateAnnouncementAsync(Guid announcementId, Announcement announcement, CancellationToken cancellationToken);
}