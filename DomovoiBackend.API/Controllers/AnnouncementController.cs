using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomovoiBackend.API.Controllers;

/// <summary>
/// Контроллер объявлений.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AnnouncementController : ControllerBase
{
    /// <summary>
    /// Сервис объявлений.
    /// </summary>
    private readonly IAnnouncementService _service;

    public AnnouncementController(IAnnouncementService service) =>
        _service = service;
    
    /// <summary>
    /// Post - новое объявление.
    /// </summary>
    /// <param name="realityType">Тип недвижимости.</param>
    /// <param name="dealType">Тип сделки.</param>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ.</returns>
    [HttpPost]
    public async Task<IActionResult> PostAnnouncement(
        AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var announcementGuid =  await _service.AddAnnouncementAsync(request, cancellationToken);
            return Ok(announcementGuid);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }

    /// <summary>
    /// Get - объявление по Id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ.</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAnnouncement(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var announcementInformation = await _service.GetAnnouncementAsync(id, cancellationToken);
            return Ok(announcementInformation);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    
    // TODO: УДАЛИТЬ - УСТАРЕЛО
    /// <summary>
    /// Get - первые N объявлений.
    /// </summary>
    /// <param name="count">N.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ.</returns>
    [HttpGet("take/{count:int}")]
    public async Task<IActionResult> GetAnnouncements(int count, CancellationToken cancellationToken)
    {
        try
        {
            var announcementInformationCollection = await _service.GetAnnouncementsAsync(count, cancellationToken);
            return Ok(announcementInformationCollection);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }
    
    /// <summary>
    /// Получить объявления.
    /// </summary>
    /// <param name="fromIndex">Индекс от.</param>
    /// <param name="toIndex">Индекс до.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ.</returns>
    [HttpGet("take")]
    public async Task<IActionResult> GetAnnouncements([FromQuery] int? fromIndex, [FromQuery] int? toIndex, CancellationToken cancellationToken)
    {
        try
        {
            var announcementInformationCollection = (toIndex != null && fromIndex != null)
                ? await _service.GetLimitedAnnouncementsAsync(fromIndex.Value, toIndex.Value, cancellationToken)
                : (fromIndex == null && toIndex != null)
                    ? await _service.GetLimitedAnnouncementsAsync(toIndex.Value, cancellationToken)
                    : await _service.GetAnnouncementsAsync(cancellationToken);
            return Ok(announcementInformationCollection);
        }
        catch(Exception exception)
        {
            return BadRequest(exception);
        }
    }
}