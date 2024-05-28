using System.Net;
using System.Net.Http.Json;
using DomovoiBackend.API.Constants.StringLiterals;
using DomovoiBackend.API.Tests.Abstractions;
using DomovoiBackend.Application.Information.Announcements;
using DomovoiBackend.Application.Parameters;

namespace DomovoiBackend.API.Tests.Announcement;

public class AnnouncementGetTests : BaseEndToEndTest
{
    public AnnouncementGetTests(EndToEndWebAppFactory factory) : base(factory) { }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_IncorrectAnnouncementGetTest()
    {
        var response = await HttpClient.GetAsync($"Announcement/{Guid.Empty}");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Api_AnnouncementEndPoint_CorrectAnnouncementGetTest()
    {
        var response = await HttpClient.GetAsync($"Announcement/{Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474")}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetManyAnnouncementsFromIndexToIndex()
    {
        const int fromIndex = 0;
        const int toIndex = 1;
        const int expectedCount = 2;

        var collection = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Take?fromIndex={fromIndex}&toIndex={toIndex}");
        
        Assert.Equal(expectedCount, collection!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetManyAnnouncementsToIndex()
    {
        const int toIndex = 2;
        const int expectedCount = 2;

        var collection = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Take?toIndex={toIndex}");
        
        Assert.Equal(expectedCount, collection!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetManyAnnouncementsToIncorrectIndex()
    {
        const int fromIndex = 2;
        const int toIndex = 1;

        var collection = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Take?fromIndex={fromIndex}&toIndex={toIndex}");
        
        Assert.Empty(collection!.AnnouncementInformation);
    }

    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByUserId()
    {
        const int expectedCount = 2;
        var userId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");
        
        var collection = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/User/{userId}");
        
        Assert.Equal(expectedCount, collection!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetById()
    {
        var announcementId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");
        
        var response = await HttpClient.GetAsync($"Announcement/{announcementId}");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByIncorrectId()
    {
        var announcementId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac478");
        
        var response = await HttpClient.GetAsync($"Announcement/{announcementId}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByFloorFilterBoth()
    {
        const int expectedCount = 2;
        const int floorFilter = (int)FloorSelectMode.Both;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?FloorFilter={floorFilter}");
        
        Assert.Equal(expectedCount, response!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByFloorFilterNotFirst()
    {
        const int expectedCount = 3;
        const int floorFilter = (int)FloorSelectMode.NotFirst;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?FloorFilter={floorFilter}");
        
        Assert.Equal(expectedCount, response!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByFloorFilterNotLast()
    {
        const int expectedCount = 2;
        const int floorFilter = (int)FloorSelectMode.NotLast;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?FloorFilter={floorFilter}");
        
        Assert.Equal(expectedCount, response!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByFloorFilterDefault()
    {
        const int expectedCount = 3;
        const int floorFilter = (int)FloorSelectMode.Default;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?FloorFilter={floorFilter}");
        
        Assert.Equal(expectedCount, response!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByPriceStartFilter()
    {
        const int expectedCount = 2;
        const int priceStart = 100_000;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?PriceStart={priceStart}");
        
        Assert.Equal(expectedCount, response!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByPriceEndFilter()
    {
        const int priceEnd = 10;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?PriceEnd={priceEnd}");
        
        Assert.Single(response!.AnnouncementInformation);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByPriceFilter()
    {
        const int priceStart = 2;
        const int priceEnd = 6;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?PriceStart={priceStart}&PriceEnd={priceEnd}");
        
        Assert.Single(response!.AnnouncementInformation);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByIncorrectPriceFilter()
    {
        const int priceStart = 25;
        const int priceEnd = 4;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?PriceStart={priceStart}&PriceEnd={priceEnd}");
        
        Assert.Empty(response!.AnnouncementInformation);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByDealTypeFilter()
    {
        const string dealType = DealStringLiteral.Rent;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?DealType={dealType}");
        
        Assert.Single(response!.AnnouncementInformation);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByRealityType()
    {
        const int expectedCount = 2;
        const string realityType = RealityStringLiteral.Office;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?RealityType={realityType}");
        
        Assert.Equal(expectedCount, response!.AnnouncementInformation.Count);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_GetByFullFilter()
    {
        const string realityType = RealityStringLiteral.Flat;
        const string dealType = DealStringLiteral.Rent;
        const double priceEnd = 100;
        const double priceStart = 2;
        const int floorFilter = (int)FloorSelectMode.NotFirst;
        
        var response = await HttpClient.GetFromJsonAsync<AnnouncementInformationCollection>($"Announcement/Filtered?" +
            $"RealityType={realityType}&" +
            $"DealType={dealType}&" +
            $"PriceEnd={priceEnd}&" +
            $"PriceStart={priceStart}&" +
            $"FloorFilter={floorFilter}");
        
        Assert.Single(response!.AnnouncementInformation);
    }
}