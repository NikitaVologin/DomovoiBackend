using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
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

    public async Task<IList<Announcement>> GetAnnouncementsByParametersAsync(FilterParameters filterParameters, OrderParameters orderParameters,
        CancellationToken cancellationToken)
    {
        var announcements = _context.Announcements.IncludeAll(_context);

        if (filterParameters.PriceStart is not null)
            announcements = announcements.Where(a => a.Deal!.Price >= filterParameters.PriceStart);
        
        if (filterParameters.PriceEnd is not null)
            announcements = announcements.Where(a => a.Deal!.Price <= filterParameters.PriceEnd);

        announcements = filterParameters.FloorFilter switch
        {
            FloorSelectMode.NotLast => announcements.Where(a =>
                ((Office)a.Reality).Floor != ((Office)a.Reality).FloorsCount),
            FloorSelectMode.NotFirst => announcements.Where(a => ((Office)a.Reality).Floor != 1),
            FloorSelectMode.Both => announcements.Where(a =>
                ((Office)a.Reality).Floor != ((Office)a.Reality).FloorsCount && ((Office)a.Reality).Floor != 1),
            _ => announcements
        };

        if (orderParameters.AreaOrder != null)
        {
            announcements = orderParameters.AreaOrder == OrderValue.Ascending ?
                announcements.OrderBy(a => a.Reality.Area) :
                announcements.OrderByDescending(a => a.Reality.Area);
        }

        if (orderParameters.PriceOrder != null)
        {
            announcements = orderParameters.PriceOrder == OrderValue.Ascending ?
                announcements.OrderBy(a => a.Deal.Price) :
                announcements.OrderByDescending(a => a.Deal.Price);
        }

        IEnumerable<Announcement> listOfAnnouncements = await announcements.ToListAsync(cancellationToken);
        
        if (filterParameters.DealType != null)
        {
            var dealType = typeof(Deal).Assembly.GetTypes().FirstOrDefault(t => t.Name == filterParameters.DealType);
            listOfAnnouncements = listOfAnnouncements.Where(a => a.Deal!.GetType() == dealType);
        }

        if (filterParameters.RealityType == null) return listOfAnnouncements.ToList();
        var realityType = typeof(Reality).Assembly.GetTypes().FirstOrDefault(t => t.Name == filterParameters.RealityType);
        if (realityType != null) listOfAnnouncements = listOfAnnouncements.Where(a => a.Deal!.GetType().IsSubclassOf(realityType));

        return listOfAnnouncements.ToList();
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
        var oldAnnouncement = await _context.Announcements.IncludeAll(_context)
            .FirstOrDefaultAsync(a => a.Id == announcementId, cancellationToken);
        if (oldAnnouncement == null) throw new DbNotFoundException(typeof(Announcement), new {Id = announcementId });
        oldAnnouncement.Update(announcement);
        await _context.SaveChangesAsync(cancellationToken);
    }
}