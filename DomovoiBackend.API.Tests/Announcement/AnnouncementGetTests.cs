using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Other;
using DomovoiBackend.Application.Information.Realities.Commercial;
using DomovoiBackend.Application.Requests.Announcements;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;

namespace DomovoiBackend.API.Tests.Announcement;

public class AnnouncementGetTests : BaseEndToEndTest
{
    public AnnouncementGetTests(EndToEndWebAppFactory factory) : base(factory) { }
    
    [Fact]
    public async Task Api_CorrectAnnouncementGetTest()
    {
        var request = new AddPhysicalCounterAgentRequest()
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        var counterAgentResponse = await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);
        var counterAgentInfo = await counterAgentResponse.Content.ReadFromJsonAsync<CounterAgentInformation>();
        
        var addAnnouncementRequest = new AddAnnouncementRequest()
        {
            CounterAgentId = counterAgentInfo!.Id,
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

        var addAnnouncementResponse = await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        var announcementGuid = await addAnnouncementResponse.Content.ReadFromJsonAsync<Guid>();

        HttpResponseMessage response = await HttpClient.GetAsync($"Announcement/{announcementGuid}");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_IncorrectAnnouncementGetTest()
    {
        HttpResponseMessage response = await HttpClient.GetAsync($"Announcement/{Guid.Empty}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Api_GetManyAnnouncementsTest()
    {
        var request = new AddPhysicalCounterAgentRequest()
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        var counterAgentResponse = await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);
        var counterAgentInfo = await counterAgentResponse.Content.ReadFromJsonAsync<CounterAgentInformation>();
        
        var addAnnouncementRequest = new AddAnnouncementRequest()
        {
            CounterAgentId = counterAgentInfo!.Id,
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
        
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);

        var collection = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/take/{int.MaxValue}");
        
        Assert.Equal(4, collection!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_GetManyAnnouncementsWithLimitTest()
    {
        const int limit = 2;
        
        var request = new AddPhysicalCounterAgentRequest()
        {
            Email = "123@mail.ru",
            Password = "12321"
        };

        var counterAgentResponse = await HttpClient.PostAsJsonAsync("CounterAgent/Physical", request);
        var counterAgentInfo = await counterAgentResponse.Content.ReadFromJsonAsync<CounterAgentInformation>();
        
        var addAnnouncementRequest = new AddAnnouncementRequest()
        {
            CounterAgentId = counterAgentInfo!.Id,
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
        
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);
        await HttpClient.PostAsJsonAsync("Announcement/Office/Rent", addAnnouncementRequest);

        var collection = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/take/{limit}");
        
        Assert.Equal(limit, collection!.AnnouncementInformation.Count);
    }
}