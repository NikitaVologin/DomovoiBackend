using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.Extensions;

internal static class FluidApiAnnouncementFilterExtension
{
    internal static IQueryable<Announcement> FilterByFloorParams(this IQueryable<Announcement> announcements, FloorSelectMode? floorFilter)
    {
        if (floorFilter == FloorSelectMode.Default || floorFilter == null) return announcements;
        announcements = floorFilter switch
        {
            FloorSelectMode.NotLast => announcements.Where(a =>
                a.Reality is IFloorCountable &&
                ((IFloorCountable)a.Reality).Floor !=
                ((IFloorCountable)a.Reality).FloorsCount),
            FloorSelectMode.NotFirst => announcements.Where(a =>
                a.Reality is IFloorCountable &&
                ((IFloorCountable)a.Reality).Floor != 1),
            FloorSelectMode.Both => announcements.Where(a =>
                a.Reality is IFloorCountable &&
                ((IFloorCountable)a.Reality).Floor !=
                ((IFloorCountable)a.Reality).FloorsCount &&
                ((IFloorCountable)a.Reality).Floor != 1),
            _ => announcements
        };
        return announcements;
    }

    internal static IQueryable<Announcement> FilterByPrices(this IQueryable<Announcement> announcements,
        double? startPrice, double? endPrice)
    {
        if (startPrice is not null)
            announcements = announcements.Where(a => a.Deal!.Price >= startPrice);
        if (endPrice is not null)
            announcements = announcements.Where(a => a.Deal!.Price <= endPrice);
        return announcements;
    }

    internal static async Task<IEnumerable<Announcement>> CastToEnumerableWithLoadingAsync(
        this IQueryable<Announcement> announcements, CancellationToken cancellationToken) => await
        announcements.ToListAsync(cancellationToken);

    internal static IEnumerable<Announcement> FilterByDealType(this IEnumerable<Announcement> announcementsEnumeration, string? dealTypeName)
    {
        if (dealTypeName == null) return announcementsEnumeration;
        
        var dealType = typeof(Deal)
            .Assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == dealTypeName);
        
        return dealType == null ?
            announcementsEnumeration :
            announcementsEnumeration.Where(a => a.Deal!.GetType() == dealType);
    }
    
    internal static IEnumerable<Announcement> FilterByRealityType(this IEnumerable<Announcement> announcementsEnumeration, string? realityTypeName)
    {
        if (realityTypeName == null) return announcementsEnumeration;
        
        var realityType = typeof(Reality)
            .Assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == realityTypeName);
        
        return realityType == null ?
            announcementsEnumeration :
            announcementsEnumeration.Where(a => a.Reality!.GetType() == realityType);
    }
}