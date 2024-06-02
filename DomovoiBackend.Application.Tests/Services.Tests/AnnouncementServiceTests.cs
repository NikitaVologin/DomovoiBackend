using AutoMapper;
using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Other;
using DomovoiBackend.Application.Information.Realities.Commercial;
using DomovoiBackend.Application.Information.Realities.Living;
using DomovoiBackend.Application.Mapping;
using DomovoiBackend.Application.Parameters;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices;
using DomovoiBackend.Application.Services.AnnouncementServices.Infrastructure;
using DomovoiBackend.Application.Services.MappingServices;
using DomovoiBackend.Application.Tests.MockRepositories;

namespace DomovoiBackend.Application.Tests.Services.Tests;

public class AnnouncementServiceTests
{
    private readonly IMapper _mapper = new Mapper(new MapperConfiguration(c =>
        c.AddProfile(new AssemblyMappingProfile(typeof(AnnouncementService).Assembly))));

    [Test]
    public async Task AnnouncementService_GetAnnouncementTest()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var announcementId = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d39a");

        var announcement = await service.GetAnnouncementAsync(announcementId, CancellationToken.None);

        Assert.That(announcement.Description, Is.EqualTo("Миллион рублей стою"));
    }
    
    [Test]
    public void AnnouncementService_GetNotExistAnnouncementTest()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});


        var announcementId = Guid.Parse("2389cb46-e6ef-42ea-813e-a46df638d39a");

        Assert.CatchAsync(async () => await service.GetAnnouncementAsync(announcementId, CancellationToken.None));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsTest()
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var announcements = await service.GetAnnouncementsAsync(int.MaxValue, CancellationToken.None);

        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(repository.Count));
    }
    
    [Test]
    public async Task AnnouncementService_AddAnnouncementTest()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var addAnnouncementRequest = new AddAnnouncementRequest()
        {
            CounterAgentId = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
            ConnectionType = "Как связаться????",
            Description = "Обстаятельства",
            DealInfo = new RentInformation()
            {
                Price = 124321,
                Conditions = new RentConditionInformation()
                {
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
            RealityInfo = new OfficeInformation()
            {
                Access = "Не не не",
                Address = "Урааа гооооооол",
                Area = 5252,
                Building = new BuildingInformation()
                {
                    BuildingYear = 123213,
                    CenterName = "ASDdas",
                    Class = "dsadsad",
                    HaveParking = true,
                    IsEquipment = false
                },
                Entry = "Ненене",
                FloorsCount = 5122,
                IsUse = false,
                Name = "Какое",
                RoomsCount = 124
            }
        };

        var guid = await service.AddAnnouncementAsync(addAnnouncementRequest, CancellationToken.None);

        var announcement = await service.GetAnnouncementAsync(guid, CancellationToken.None);

        Assert.That(addAnnouncementRequest.RealityInfo.Area, Is.EqualTo(announcement.RealityInfo.Area));
    }

    [Test]
    public async Task AnnouncementService_GetAnnouncementsWithIndexes()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});


        var announcements = await service.GetLimitedAnnouncementsAsync(1, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(1));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsWithWrongIndexes()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});


        var announcements = await service.GetLimitedAnnouncementsAsync(2, 0, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Is.Empty);
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsWithOneItem()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});


        var announcements = await service.GetLimitedAnnouncementsAsync(1, 1, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(1));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsWithTwoIndexes()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var announcements = await service.GetLimitedAnnouncementsAsync(0, 1, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(2));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsByUserId()
    {
        var repository = new AnnouncementMockRepository();

        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var announcements = await service.GetAnnouncementByUserIdAsync(Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"), CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(repository.Count));
    }
    
    [Test]
    public async Task AnnouncementService_RemoveAnnouncement()
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        await service.RemoveAnnouncementAsync(Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d34a"),
            Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
            CancellationToken.None);

        var announcements = await service.GetAnnouncementsAsync(CancellationToken.None);

        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(2));
    }
    
    [Test]
    public async Task AnnouncementService_RemoveAnnouncementWithWrongCounterAgentId()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});
        
        Assert.CatchAsync(async () => await service.RemoveAnnouncementAsync(Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d34a"),
            Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbd"), CancellationToken.None));
    }
    
    [Test]
    public async Task AnnouncementService_RemoveAnnouncementWithWrongAnnouncementId()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});
        
        Assert.CatchAsync(async () => await service.RemoveAnnouncementAsync(Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d34d"),
            Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"), CancellationToken.None));
    }
    
    [Test]
    public async Task AnnouncementService_UpdateAnnouncement()
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});


        var id = Guid.Parse("5389cb46-e6ef-42ea-813e-a46df628d34a");
        
        var updated = new UpdateAnnouncementRequest()
        {
            ConnectionType = "Душевная",
            CounterAgentId = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
            DealInfo = new RentInformation()
            {
                Price = double.Pi,
                Conditions = new RentConditionInformation()
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
            RealityInfo = new FlatInformation()
            {
                Address = "ул. ХУХУХУ",
                Building = new ApartmentHouseInformation()
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
                }
            }
        };

        var oldAnnouncement = await service.GetAnnouncementAsync(id, CancellationToken.None);

        await service.UpdateAnnouncementAsync(id, updated,
            CancellationToken.None);

        var newAnnouncement = await service.GetAnnouncementAsync(id, CancellationToken.None);
        
        Assert.That(newAnnouncement.RealityInfo.Address, Is.Not.EqualTo(oldAnnouncement.RealityInfo.Address));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsByStartPrice()
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var filter = new FilterParameters()
        {
            PriceStart = 100_000
        };

        const int expectedCountAfterFilter = 2;
        const int expectedPrice = 124321;

        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
        Assert.That(announcements.AnnouncementInformation[0].DealInfo!.Price, Is.EqualTo(expectedPrice));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsByEndPrice()
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var filter = new FilterParameters()
        {
            PriceEnd = 10
        };

        const int expectedCountAfterFilter = 1;
        const double expectedPrice = double.Pi;

        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
        Assert.That(announcements.AnnouncementInformation[0].DealInfo!.Price, Is.EqualTo(expectedPrice));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsByStartAndEndPrice()
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});


        var filter = new FilterParameters()
        {
            PriceStart = 6,
            PriceEnd = 10
        };

        const int expectedCountAfterFilter = 0;

        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
    }
    
    [TestCase(FloorSelectMode.NotFirst, 2)]
    [TestCase(FloorSelectMode.NotLast, 2)]
    [TestCase(FloorSelectMode.Default, 3)]
    [TestCase(FloorSelectMode.Both, 1)]
    [TestCase(null, 3)]
    public async Task AnnouncementService_GetAnnouncementsByStartAndEndPrice(FloorSelectMode? selectMode,
        int expectedCountAfterFilter)
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var filter = new FilterParameters()
        {
            FloorFilter = selectMode
        };
        
        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
    }
    
    [TestCase(RealityStringLiteral.Flat, 1)]
    [TestCase(RealityStringLiteral.Office, 2)]
    [TestCase(null, 3)]
    public async Task AnnouncementService_GetAnnouncementsByRealityType(string? realityTypeName,
        int expectedCountAfterFilter)
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var filter = new FilterParameters()
        {
            RealityType = realityTypeName
        };
        
        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
    }
    
    [TestCase(DealStringLiteral.Rent, 3)]
    [TestCase(DealStringLiteral.Sell, 0)]
    [TestCase(null, 3)]
    public async Task AnnouncementService_GetAnnouncementsByDealType(string? dealTypeName,
        int expectedCountAfterFilter)
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var filter = new FilterParameters()
        {
            DealType = dealTypeName
        };
        
        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
    }
    
    [TestCase(0, 5, FloorSelectMode.NotFirst, RealityStringLiteral.Flat, DealStringLiteral.Rent, 1)]
    [TestCase(null, 150_000, FloorSelectMode.NotLast, RealityStringLiteral.Office, DealStringLiteral.Rent, 1)]
    [TestCase(100_000, 150_000, FloorSelectMode.Default, RealityStringLiteral.Office, DealStringLiteral.Rent, 2)]


    public async Task AnnouncementService_GetAnnouncementsWithFullFilter(double? startPrice,
        double? endPrice,
        FloorSelectMode? floorSelect,
        string? realityTypeName,
        string? dealTypeName,
        int expectedCountAfterFilter)
    {
        var repository = new AnnouncementMockRepository();
        
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            repository,
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper),
            new AnnouncementServiceOptions() { PicturesDirectory = "/Pictures/Announcements/"});

        var filter = new FilterParameters()
        {
            PriceStart = startPrice,
            PriceEnd = endPrice,
            FloorFilter = floorSelect,
            RealityType = realityTypeName,
            DealType = dealTypeName
        };
        
        var announcements = await service.GetFilteredAnnouncementsAsync(filter, CancellationToken.None);
        
        Assert.That(announcements.AnnouncementInformation, Has.Count.EqualTo(expectedCountAfterFilter));
    }
}