using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Persistence.EfSettings;
using DomovoiBackend.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Repositories.EfRepositories;

/// <summary>
/// EF Репозиторий объявлений.
/// </summary>
public class EfAnnouncementRepository : IAnnouncementRepository
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
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
        var announcement =  await _context.Announcements
            .IncludeAll(_context)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        if (announcement == null) throw new DbNotFoundException(typeof(Announcement), id);
        return announcement;
    }

    public async Task<IList<Announcement>> GetAnnouncementsAsync(int count, CancellationToken cancellationToken)
    {
        return await _context.Announcements
            .IncludeAll(_context)
            .Take(count)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<Announcement>> GetAnnouncementsAsync(CancellationToken cancellationToken)
    {
        return await _context.Announcements
            .IncludeAll(_context)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<Announcement>> GetAnnouncementsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Announcements
            .IncludeAll(_context)
            .Where(a => a.CounterAgent!.Id == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<Announcement>> GetLimitedAnnouncementsAsync(int toIndex, CancellationToken cancellationToken)
    {
        return await _context.Announcements
            .IncludeAll(_context)
            .Take(toIndex)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<Announcement>> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex, CancellationToken cancellationToken)
    {
        return await _context.Announcements
            .IncludeAll(_context)
            .Skip(fromIndex )
            .Take(toIndex - fromIndex + 1)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<Announcement>> GetAnnouncementsByParametersAsync(FilterParameters filterParameters,
        CancellationToken cancellationToken)
    {
        var announcementsEnumeration = await _context
            .Announcements
            .IncludeAll(_context)
            .FilterByPrices(filterParameters.PriceStart,
                filterParameters.PriceEnd)
            .CastToEnumerableWithLoadingAsync(cancellationToken);

        return announcementsEnumeration
            .FilterByFloorParams(filterParameters.FloorFilter)
            .FilterByDealType(filterParameters.DealType)
            .FilterByRealityType(filterParameters.RealityType)
            .ToList();
    }

    public async Task RemoveAnnouncementAsync(Guid counterAgentId, Guid announcementId, CancellationToken cancellationToken)
    {
        var announcement = await _context.Announcements.FirstOrDefaultAsync(a => a.Id == announcementId &&
            a.CounterAgent!.Id == counterAgentId, cancellationToken);
        if (announcement == null) throw new DbNotFoundException(typeof(Announcement), new {Id = announcementId, CounterAgentId = counterAgentId});
        _context.Announcements.Remove(announcement);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAnnouncementAsync(Guid announcementId, Announcement announcement, CancellationToken cancellationToken)
    {
        var oldAnnouncement = await _context.Announcements
            .IncludeAll(_context)
            .FirstOrDefaultAsync(a => a.Id == announcementId, cancellationToken);
        if (oldAnnouncement == null) throw new DbNotFoundException(typeof(Announcement), new {Id = announcementId });
        oldAnnouncement.Update(announcement);
        await _context.SaveChangesAsync(cancellationToken);
    }
}