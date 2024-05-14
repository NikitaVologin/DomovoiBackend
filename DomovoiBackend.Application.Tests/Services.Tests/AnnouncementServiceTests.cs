using AutoMapper;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Other;
using DomovoiBackend.Application.Information.Realities.Commercial;
using DomovoiBackend.Application.Mapping;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Services.AnnouncementServices;
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
            new CounterAgentMappingService(_mapper));

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
            new CounterAgentMappingService(_mapper));

        var announcementId = Guid.Parse("2389cb46-e6ef-42ea-813e-a46df638d39a");

        Assert.CatchAsync(async () => await service.GetAnnouncementAsync(announcementId, CancellationToken.None));
    }
    
    [Test]
    public async Task AnnouncementService_GetAnnouncementsTest()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper));

        var announcements = await service.GetAnnouncementsAsync(int.MaxValue, CancellationToken.None);

        Assert.That(announcements.AnnouncementInformation.Count, Is.EqualTo(2));
    }
    
    [Test]
    public async Task AnnouncementService_AddAnnouncementTest()
    {
        var service = new AnnouncementService(
            new DealMappingService(_mapper),
            new RealityMappingService(_mapper),
            new AnnouncementMockRepository(),
            new CounterAgentMockRepository(),
            new CounterAgentMappingService(_mapper));

        var addAnnouncementRequest = new AddAnnouncementRequest()
        {
            CounterAgentId = Guid.Parse("a275f7c5-be57-4c52-bfb8-1b12d0fccbbc"),
            ConnectionType = "Как связаться????",
            Description = "Обстаятельства",
            DealInfo = new RentInformation()
            {
                Conditions = new RentConditionInformation()
                {
                    CommunalPays = 2525,
                    Deposit = 124214,
                    Period = "Ежесекундно",
                    Prepay = 1234124,
                    Price = 124321,
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
}