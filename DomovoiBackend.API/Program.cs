using DomovoiBackend.API.Middlewares;
using DomovoiBackend.Application;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.RentInformation;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.SellInformation;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.TypesRequest;
using DomovoiBackend.Application.Models.CounterAgents;
using DomovoiBackend.Application.Models.CounterAgents.ConcreteRequests;
using DomovoiBackend.Persistence;
using JsonSubTypes;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "DomovoiBackend.API",
            Version = "v1"
        });
    options.UseAllOfToExtendReferenceSchemas();
    options.UseAllOfForInheritance();
    options.UseOneOfForPolymorphism();
});


// TODO: Сделать нормальную конфигурацию сериализации подтипов.
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(CounterAgentRequestInfo), "counterAgentType")
                .RegisterSubtype<PhysicalCounterAgentRequestInfo>("PhysicalCounterAgent")
                .RegisterSubtype<LegalCounterAgentRequestInfo>("LegalCounterAgent")
                .SerializeDiscriminatorProperty()
                .Build());
        
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(RealityRequestInfo), "realityType")
                .RegisterSubtype<OfficeRequestInfo>("Office")
                .SerializeDiscriminatorProperty()
                .Build());
        
        options.SerializerSettings.Converters.Add(
            JsonSubtypesConverterBuilder
                .Of(typeof(DealRequestInfo), "dealType")
                .RegisterSubtype<RentRequestInfo>("Rent")
                .RegisterSubtype<SellRequestInfo>("Sell")
                .SerializeDiscriminatorProperty()
                .Build());
    });

// TODO: Доделать ApplicationLayer и PersistenceLayer (RUD);
builder.Services.AddApplicationLayer()
    .AddPersistence(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors",
        policy  =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("cors");

// TODO: Сделать одно middleware для каждого вида запросов с подтипами.
app.UseMiddleware<AnnouncementRouteTransformerMiddleware>();
app.UseMiddleware<CounterAgentRouteTransformerMiddleware>();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
