using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomovoiBackend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnouncementController : ControllerBase
{
    private readonly IAnnouncementService _service;

    public AnnouncementController(IAnnouncementService service) =>
        _service = service;
    
    [HttpPost("{realityType}/{dealType}")]
    public async Task<Guid> PostAnnouncement(string realityType,
        string dealType,
        AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        return await _service.AddAnnouncementAsync(request, cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<AnnouncementInformation> GetAnnouncement(Guid id, CancellationToken cancellationToken) =>
        await _service.GetAnnouncementAsync(id, cancellationToken);
}