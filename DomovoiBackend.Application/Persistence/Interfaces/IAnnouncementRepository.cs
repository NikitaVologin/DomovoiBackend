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

    /// <summary>
    /// Получить первые I объявлений.
    /// </summary>
    /// <param name="count">Количество объвялений.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список объявлений.</returns>
    Task<IList<Announcement>> GetAnnouncementsAsync(int count, CancellationToken cancellationToken);
}