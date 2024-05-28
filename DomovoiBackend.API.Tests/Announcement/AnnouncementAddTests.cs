using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Information.Deals.Rents;
using DomovoiBackend.Application.Information.Other;

namespace DomovoiBackend.API.Tests.Announcement;

public class AnnouncementAddTests : BaseEndToEndTest
{
    public AnnouncementAddTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async Task Api_AnnouncementEndPoint_CorrectAnnouncementAddTest()
    {
        var addAnnouncementRequest = new
        {
            CounterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474"),
            ConnectionType = "Как связаться????",
            Description = "Обстаятельства",
            DealInfo = new
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
                },
                Type = DealStringLiteral.Rent
            },
            RealityInfo = new
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
                RoomsCount = 124,
                Type = RealityStringLiteral.Office
            }
        };

        var response = await HttpClient.PostAsJsonAsync("Announcement", addAnnouncementRequest);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_CorrectAnnouncementAddWithNotExistCounterAgent()
    {
        var addAnnouncementRequest = new
        {
            CounterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac477"),
            ConnectionType = "Как связаться????",
            Description = "Обстаятельства",
            DealInfo = new
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
                },
                Type = "Rent"
            },
            RealityInfo = new
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
                RoomsCount = 124,
                Type="Office"
            }
        };

        var response = await HttpClient.PostAsJsonAsync("Announcement", addAnnouncementRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    
}