using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Deals.Rents;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Interfaces;

namespace DomovoiBackend.Application.Tests.MockRepositories;

public class AnnouncementMockRepository : IAnnouncementRepository
{
    public int Count => _mockData.Count;
    
    private readonly List<Announcement> _mockData =
    [
        new Announcement
        {
            Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
            ConnectionType = "Душевная",
            CounterAgent = new PhysicalCounterAgent()
            {
                ContactNumber = "123",
                Email = "123@mail.ru",
                FIO = "Alla Pugachevo Zhest",
                Id = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
                Password = "123"
            },
            Deal = new Rent()
            {
                Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                Price = 124321,
                Conditions = new RentConditions()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    CommunalPays = 2525,
                    Deposit = 124214,
                    Period = "Ежесекундно",
                    Prepay = 1234124,
                    CanSmoke = true,
                    Facilities = "Aaaa",
                    WithKids = true,
                    WithAnimals = true
                }
            },
            Description = "Миллион рублей стою",
            Reality = new Office()
            {
                Address = "Куртой",
                Access = "Не надо",
                Area = 12421,
                Building = new Building()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    BuildingYear = 20241,
                    CenterName = "Ааа",
                    Class = "Ббб",
                    HaveParking = true,
                    IsEquipment = true
                },
                Floor = 25,
                FloorsCount = 25
            }
        },
        new Announcement
        {
            Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
            ConnectionType = "Душевная",
            CounterAgent = new PhysicalCounterAgent()
            {
                ContactNumber = "123",
                Email = "123@mail.ru",
                FIO = "Alla Pugachevo Zhest",
                Id = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
                Password = "123"
            },
            Deal = new Rent()
            {
                Price = 124321,
                Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                Conditions = new RentConditions()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    CommunalPays = 2525,
                    Deposit = 124214,
                    Period = "Ежесекундно",
                    Prepay = 1234124,
                    CanSmoke = true,
                    Facilities = "Aaaa",
                    WithKids = true,
                    WithAnimals = true
                }
            },
            Description = "Миллион рублей стою",
            Reality = new Office()
            {
                Address = "Куртой",
                Access = "Не надо",
                Area = 12421,
                Building = new Building()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    BuildingYear = 20241,
                    CenterName = "Ааа",
                    Class = "Ббб",
                    HaveParking = true,
                    IsEquipment = true
                },
                FloorsCount = 25,
                Floor = 1
            }
        },
        new Announcement
        {
            Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d34a"),
            ConnectionType = "Душевная",
            CounterAgent = new PhysicalCounterAgent()
            {
                ContactNumber = "123",
                Email = "123@mail.ru",
                FIO = "Alla Pugachevo Zhest",
                Id = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
                Password = "123"
            },
            Deal = new Rent()
            {
                Price = double.Pi,
                Conditions = new  RentConditions()
                {
                    CommunalPays = 202,
                    CanSmoke = true,
                    Deposit = 1515,
                    Facilities = "Удобненько",
                    Period = "Периодично",
                    Prepay = 1000000,
                    WithKids = false,
                    WithAnimals = true
                }
            },
            Description = "Миллион рублей стою",
            Reality = new Flat()
            {
                Address = "ул. ХИХИХИХА",
                Building = new ApartmentHouse()
                {
                    BuildingYear = 2022,
                    CeilingHeight = 252,
                    HaveGarbageChute = true,
                    HaveParking = true,
                    Infrastructures = ["Туалет", "Унитаз"],
                    IsSecurity = true,
                    IsGas = false,
                    Landscaping = ["Жёсткая желтень"],
                    Type = "Жёсткий",
                },
                Floor = 25,
                FloorsCount = 30
            }
        }
    ];

    public Task<Guid> AddAnnouncementAsync(Announcement announcement, CancellationToken cancellationToken)
    {
        if (announcement.Id == default)
            announcement.Id = Guid.Parse("d1e2b9d8-adcc-428c-81e0-1aacd9218f35");
        _mockData.Add(announcement);
        return Task.FromResult(announcement.Id);
    }

    public Task<Announcement> GetAnnouncementAsync(Guid id, CancellationToken cancellationToken)
    {
        var announcement = _mockData.FirstOrDefault(a => a.Id == id);
        if (announcement == default) throw new DbNotFoundException(typeof(Announcement), id);
        return Task.FromResult(announcement);
    }

    public Task<IList<Announcement>> GetAnnouncementsAsync(int count, CancellationToken cancellationToken)
    {
        var announcement = _mockData.Take(count).ToList();
        return Task.FromResult((IList<Announcement>)announcement);
    }

    public Task<IList<Announcement>> GetAnnouncementsAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult((IList<Announcement>)_mockData);
    }

    public Task<IList<Announcement>> GetAnnouncementsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return Task.FromResult((IList<Announcement>)_mockData.Where(a => a.CounterAgent!.Id == userId).ToList());
    }

    public Task<IList<Announcement>> GetLimitedAnnouncementsAsync(int toIndex, CancellationToken cancellationToken)
    {
        var announcement = _mockData.Take(toIndex).ToList();
        return Task.FromResult((IList<Announcement>)announcement);
    }

    public Task<IList<Announcement>> GetLimitedAnnouncementsAsync(int fromIndex, int toIndex, CancellationToken cancellationToken)
    {
        var announcement = _mockData.Skip(fromIndex).Take(toIndex - fromIndex + 1).ToList();
        return Task.FromResult((IList<Announcement>)announcement);
    }

    public Task<IList<Announcement>> GetAnnouncementsByParametersAsync(FilterParameters filterParameters,
        CancellationToken cancellationToken)
    {
        var filteredAnnouncements = _mockData
            .FilterByPrices(filterParameters.PriceStart,
                filterParameters.PriceEnd)
            .FilterByFloorParams(filterParameters.FloorFilter)
            .FilterByDealType(filterParameters.DealType)
            .FilterByRealityType(filterParameters.RealityType)
            .ToList();

        return Task.FromResult(filteredAnnouncements as IList<Announcement>);
    }

    public Task RemoveAnnouncementAsync(Guid counterAgentId, Guid announcementId, CancellationToken cancellationToken)
    {
        var announcement = _mockData.FirstOrDefault(announcement => announcement.CounterAgent!.Id == counterAgentId &&
                                                           announcement.Id == announcementId);

        if (announcement == null) throw new Exception();

        _mockData.Remove(announcement);
        
        return Task.CompletedTask;
    }

    public Task UpdateAnnouncementAsync(Guid announcementId, Announcement updatedAnnouncement, CancellationToken cancellationToken)
    {
        var announcement = _mockData.FirstOrDefault(announcement => announcement.Id == announcementId);

        if (announcement == null) throw new Exception();

        _mockData.Remove(announcement);
        
        announcement.Update(updatedAnnouncement);
        
        _mockData.Add(announcement);

        return Task.CompletedTask;
    }
}

internal static class EnumerableLinqExtensionsForTests
{
    internal static IEnumerable<Announcement> FilterByFloorParams(
        this IEnumerable<Announcement> announcementsEnumerate, FloorSelectMode? floorFilter)
    {
        if (floorFilter is null or FloorSelectMode.Default) return announcementsEnumerate;
        announcementsEnumerate = floorFilter switch
        {
            FloorSelectMode.NotLast => announcementsEnumerate.Where(a =>
                a.Reality is IFloorCountable floorCountable &&
                floorCountable.Floor !=
                floorCountable.FloorsCount),
            FloorSelectMode.NotFirst => announcementsEnumerate.Where(a =>
                a.Reality is IFloorCountable floorCountable &&
                floorCountable.Floor != 1),
            FloorSelectMode.Both => announcementsEnumerate.Where(a =>
                a.Reality is IFloorCountable floorCountable &&
                floorCountable.Floor !=
                floorCountable.FloorsCount &&
                floorCountable.Floor != 1),
            _ => announcementsEnumerate
        };
        return announcementsEnumerate;
    }

    internal static IEnumerable<Announcement> FilterByPrices(this IEnumerable<Announcement> announcements,
        double? startPrice, double? endPrice)
    {
        if (startPrice is not null)
            announcements = announcements.Where(a => a.Deal!.Price >= startPrice);
        if (endPrice is not null)
            announcements = announcements.Where(a => a.Deal!.Price <= endPrice);
        return announcements;
    }

    internal static IEnumerable<Announcement> FilterByDealType(this IEnumerable<Announcement> announcementsEnumeration,
        string? dealTypeName)
    {
        if (dealTypeName == null) return announcementsEnumeration;

        var dealType = typeof(Deal)
            .Assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == dealTypeName);

        return dealType == null
            ? announcementsEnumeration
            : announcementsEnumeration.Where(a => a.Deal!.GetType() == dealType);
    }

    internal static IEnumerable<Announcement> FilterByRealityType(
        this IEnumerable<Announcement> announcementsEnumeration, string? realityTypeName)
    {
        if (realityTypeName == null) return announcementsEnumeration;

        var realityType = typeof(Reality)
            .Assembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == realityTypeName);

        return realityType == null
            ? announcementsEnumeration
            : announcementsEnumeration.Where(a => a.Reality!.GetType() == realityType);
    }
}