using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Information.Deals.Sells;
using DomovoiBackend.Application.Information.Other;

namespace DomovoiBackend.API.Tests.Announcement;

public class AnnouncementUpdateTests : BaseEndToEndTest
{
    public AnnouncementUpdateTests(EndToEndWebAppFactory factory) : base(factory) { }

    [Fact]
    public async Task Api_AnnouncementEndPoint_Update()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");

        var updateRequest = new
        {
            ConnectionType = "Мысленная",
            CounterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474"),
            DealInfo = new
            {
                Price = 4_241_241,
                Conditions = new SellConditionInformation()
                {
                    HaveChildPrescribers = true,
                    HaveChildOwners = true,
                    OwnersCount = 1000,
                    PrescribersCount = 22421,
                    Type = "Ыыыы",
                    YearInOwn = 2014
                },
                Type = DealStringLiteral.Sell
            },
            RealityInfo = new
            {
                Access = "СС",
                Address = "г. ЫЫЫ ул.Тюмень д.52151",
                Area = 1228,
                Floor = 14,
                Building = new BuildingInformation()
                {
                    BuildingYear = 2021,
                    CenterName = "ППППП Ыыыыы",
                    Class = "Первый классный",
                    HaveParking = true,
                    IsEquipment = true
                },
                Entry = "Ааааа",
                FloorsCount = 525,
                IsUse = true,
                Name = "Фамилия",
                RoomsCount = 6262,
                Type = RealityStringLiteral.Office
            },
            Description = "Крутое"
        };

        var response = await HttpClient.PutAsJsonAsync($"/Announcement/{id}", updateRequest);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_UpdateWithIncorrectId()
    {
        var id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac478");

        var updateRequest = new
        {
            ConnectionType = "Мысленная",
            CounterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474"),
            DealInfo = new
            {
                Price = 4_241_241,
                Conditions = new SellConditionInformation()
                {
                    HaveChildPrescribers = true,
                    HaveChildOwners = true,
                    OwnersCount = 1000,
                    PrescribersCount = 22421,
                    Type = "Ыыыы",
                    YearInOwn = 2014
                },
                Type = DealStringLiteral.Sell
            },
            RealityInfo = new
            {
                Access = "СС",
                Address = "г. ЫЫЫ ул.Тюмень д.52151",
                Area = 1228,
                Floor = 14,
                Building = new BuildingInformation()
                {
                    BuildingYear = 2021,
                    CenterName = "ППППП Ыыыыы",
                    Class = "Первый классный",
                    HaveParking = true,
                    IsEquipment = true
                },
                Entry = "Ааааа",
                FloorsCount = 525,
                IsUse = true,
                Name = "Фамилия",
                RoomsCount = 6262,
                Type = RealityStringLiteral.Office
            },
            Description = "Крутое"
        };

        var response = await HttpClient.PutAsJsonAsync($"/Announcement/{id}", updateRequest);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}