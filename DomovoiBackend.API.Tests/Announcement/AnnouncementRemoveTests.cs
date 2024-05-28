using System.Net;
using DomovoiBackend.API.Tests.Abstractions;

namespace DomovoiBackend.API.Tests.Announcement;

public class AnnouncementRemoveTests : BaseEndToEndTest
{
    public AnnouncementRemoveTests(EndToEndWebAppFactory factory) : base(factory) { }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_Delete()
    {
        var announcementId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");
        var counterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");

        var response = await HttpClient.DeleteAsync($"Announcement/{counterAgentId}/{announcementId}");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_DeleteWithIncorrectCounterAgentId()
    {
        var announcementId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");
        var counterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac475");

        var response = await HttpClient.DeleteAsync($"Announcement/{counterAgentId}/{announcementId}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Api_AnnouncementEndPoint_DeleteWithIncorrectAnnouncementId()
    {
        var announcementId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac475");
        var counterAgentId = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474");

        var response = await HttpClient.DeleteAsync($"Announcement/{counterAgentId}/{announcementId}");
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}