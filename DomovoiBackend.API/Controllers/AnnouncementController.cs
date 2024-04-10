using DomovoiBackend.Application.Models.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
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
    public async Task<Announcement> RentPost(string realityType,
        string dealType,
        AddAnnouncementRequest request, CancellationToken cancellationToken)
    {
        return await _service.AddAnnouncementAsync(request, cancellationToken);
    }
    
    [HttpGet("{id}")]
    public async Task<Announcement> RentGet(Guid id, CancellationToken cancellationToken)
    {
        return await _service.GetAnnouncementAsync(id, cancellationToken);
    }
}