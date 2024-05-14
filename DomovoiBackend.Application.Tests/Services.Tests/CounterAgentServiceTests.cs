using AutoMapper;
using DomovoiBackend.Application.Information.CounterAgents;
using DomovoiBackend.Application.Mapping;
using DomovoiBackend.Application.Requests.CounterAgents.AddRequests;
using DomovoiBackend.Application.Requests.CounterAgents.AuthorizeRequest;
using DomovoiBackend.Application.Services.CounterAgentServices;
using DomovoiBackend.Application.Services.MappingServices;
using DomovoiBackend.Application.Tests.MockRepositories;

namespace DomovoiBackend.Application.Tests.Services.Tests;

public class CounterAgentServiceTests
{
    private readonly IMapper _mapper = new Mapper(new MapperConfiguration(c =>
        c.AddProfile(new AssemblyMappingProfile(typeof(CounterAgentService).Assembly))));
    
    [Test]
    public async Task CounterAgentService_AddPhysicalCounterAgentTest()
    {
        var service = new CounterAgentService(new CounterAgentMockRepository(), new CounterAgentMappingService(_mapper));
        var counterAgentAddRequest = new AddPhysicalCounterAgentRequest
        {
            Email = "majorka@mail.ru",
            Password = "1243"
        };
        var counterAgentInformation = await service.AddAsync(counterAgentAddRequest, CancellationToken.None);

        var physicalCounterAgent = counterAgentInformation as PhysicalCounterAgentInformation;
        
        Assert.That(physicalCounterAgent, Is.Not.Null);
    }
    
    [Test]
    public async Task CounterAgentService_TryTwiceAddPhysicalCounterAgentTest()
    {
        var service = new CounterAgentService(new CounterAgentMockRepository(), new CounterAgentMappingService(_mapper));
        var counterAgentAddRequest = new AddPhysicalCounterAgentRequest
        {
            Email = "majorka@mail.ru",
            Password = "1243"
        };
        
        await service.AddAsync(counterAgentAddRequest, CancellationToken.None);

        Assert.CatchAsync(async () =>
        {
            await service.AddAsync(counterAgentAddRequest, CancellationToken.None);
        });
    }
    
    [Test]
    public async Task CounterAgentService_AddLegalCounterAgentTest()
    {
        var service = new CounterAgentService(new CounterAgentMockRepository(), new CounterAgentMappingService(_mapper));
        var counterAgentAddRequest = new AddLegalCounterAgentRequest()
        {
            Email = "majorka@mail.ru",
            Password = "1243"
        };
        var counterAgentInformation = await service.AddAsync(counterAgentAddRequest, CancellationToken.None);

        var legalCounterAgent = counterAgentInformation as LegalCounterAgentInformation;
        
        Assert.That(legalCounterAgent, Is.Not.Null);
    }

    [Test]
    public void CounterAgentService_LoginNotExistCounterAgentTest()
    {
        var service = new CounterAgentService(new CounterAgentMockRepository(), new CounterAgentMappingService(_mapper));

        Assert.CatchAsync(async () =>
        {
            await service.LoginAsync(new AuthorizationRequest { Email = "123421412@mail.ru", Password = "123" },
                CancellationToken.None);
        });
    }
    
    [Test]
    public void CounterAgentService_LoginWithIncorrectPasswordTest()
    {
        var service = new CounterAgentService(new CounterAgentMockRepository(), new CounterAgentMappingService(_mapper));

        Assert.CatchAsync(async () =>
        {
            await service.LoginAsync(new AuthorizationRequest { Email = "123@mail.ru", Password = "1234" },
                CancellationToken.None);
        });
    }
    
    [Test]
    public void CounterAgentService_CorrectLoginTest()
    {
        var service = new CounterAgentService(new CounterAgentMockRepository(), new CounterAgentMappingService(_mapper));

        Assert.DoesNotThrowAsync(async () =>
        {
            await service.LoginAsync(new AuthorizationRequest { Email = "123@mail.ru", Password = "123" },
                CancellationToken.None);
        });
    }
}