using DomovoiBackend.Application.Persistence.Exceptions;
using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Entities.Deals.Rents;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;

namespace DomovoiBackend.Application.Tests.MockRepositories;

public class AnnouncementMockRepository : IAnnouncementRepository
{
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
                RentRules = new RentRules()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    CanSmoke = true,
                    Facilities = "Aaaa",
                    WithKids = true,
                    WithAnimals = true
                },
                RentConditions = new RentConditions()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    CommunalPays = 2525,
                    Deposit = 124214,
                    Period = "Ежесекундно",
                    Prepay = 1234124,
                    Price = 124321
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
                }
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
                Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                RentRules = new RentRules()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    CanSmoke = true,
                    Facilities = "Aaaa",
                    WithKids = true,
                    WithAnimals = true
                },
                RentConditions = new RentConditions()
                {
                    Id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a"),
                    CommunalPays = 2525,
                    Deposit = 124214,
                    Period = "Ежесекундно",
                    Prepay = 1234124,
                    Price = 124321
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
                }
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
}