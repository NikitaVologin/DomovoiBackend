using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Persistence.EfSettings;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Repositories.EfRepositories;

public class EfAnnouncementRepository : IAnnouncementRepository
{
    private readonly DomovoiContext _context;

    public EfAnnouncementRepository(DomovoiContext context) => _context = context;

    public async Task<Guid> AddAnnouncementAsync(Announcement announcement, CancellationToken cancellationToken)
    {
        await _context.Announcements.AddAsync(announcement, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return announcement.Id;
    }
    
    public async Task<Announcement> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = _context.Announcements;
        await query.Include(a => a.CounterAgent).LoadAsync(cancellationToken);
        await query.Include(a => a.Deal).LoadAsync(cancellationToken);
        await query.Include(a => a.Reality).LoadAsync(cancellationToken);
        
        return await query.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }
}