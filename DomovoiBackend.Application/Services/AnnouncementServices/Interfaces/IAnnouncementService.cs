using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Requests.Announcements;

namespace DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;

/// <summary>
/// Интерфейс сервиса объявлений.
/// </summary>
public interface IAnnouncementService
{
    /// <summary>
    /// Добавить объявление.
    /// </summary>
    /// <param name="request">Запрос на добавление объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Id объявления.</returns>
    Task<Guid> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получпить объявление по Id.
    /// </summary>
    /// <param name="id">Id объявления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Объявление.</returns>
    Task<AnnouncementInformation> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken);
    
    // TODO: УДАЛИТЬ - УСТАРЕЛО
    /// <summary>
    /// Получить первые N объявлений.
    /// </summary>
    /// <param name="count">N</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<AnnouncementInformationCollection> GetAnnouncementsAsync(int count, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить все объявления.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<AnnouncementInformationCollection> GetAnnouncementsAsync(CancellationToken cancellationToken);

    
    /// <summary>
    /// Получить первые N объявлений.
    /// </summary>
    /// <param name="toIndex">N</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int toIndex, CancellationToken cancellationToken);

    /// <summary>
    /// Получить от A до B объявления.
    /// </summary>
    /// <param name="fromIndex">A</param>
    /// <param name="toIndex">B</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекция объявлений.</returns>
    Task<AnnouncementInformationCollection> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex, CancellationToken cancellationToken);

}