using DomovoiBackend.Application.Persistence.Interfaces;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Entities.Deals.Rents;
using DomovoiBackend.Domain.Entities.Deals.Sells;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Persistence.EfSettings;
using DomovoiBackend.Persistence.Repositories.EfRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomovoiBackend.Persistence;

/// <summary>
/// DI для Persistence слоя.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить Persistence слой.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <param name="configuration">Конфигурация.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        services.AddDbContext<DomovoiContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IAnnouncementRepository, EfAnnouncementRepository>();
        services.AddScoped<ICounterAgentRepository, EfCounterAgentRepository>();
        services.AddScoped<IChatRepository, EfChatRepository>();
        services.AddScoped<IReviewRepository, EfReviewRepository>();
        return services;
    }

    /// <summary>
    /// Пересоздать БД.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов.</returns>
    public static IServiceCollection CreateDatabase(this IServiceCollection services)
    {
        var dbContext = services.BuildServiceProvider()
            .GetRequiredService<DomovoiContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        return services;
    }

    public static IServiceCollection FillDatabase(this IServiceCollection services)
    {
        var dbContext = services.BuildServiceProvider()
            .GetRequiredService<DomovoiContext>();

        CounterAgent[] counterAgents =
        [
            new LegalCounterAgent
            {
                Id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474"),
                Email = "123@mail.ru",
                Password = "123456",
                Name = "ООО Золотой Унитаз",
                Tin = "1222",
                ContactNumber = "+7 (228) 228 22-88",
            },
            new PhysicalCounterAgent
            {
                Id = Guid.Parse("31518932-1c49-4397-8b2d-63bab308fd12"),
                Email = "124@mail.ru",
                Password = "Pudge",
                FIO = "Ridge Gidge Alidge",
                ContactNumber = "+ 7 (228) 229 22-30",
            }
        ];
        
        dbContext.CounterAgents.AddRange(counterAgents);
        dbContext.SaveChanges();
        
         Announcement[] announcements =
        [
            new Announcement
            { 
                Id = Guid.Parse("0715a242-e05a-4906-a508-b28cd96ac474"),
                ConnectionType = "Мысленная",
                CounterAgent = counterAgents[0],
                Deal = new Sell()
                {
                    Price = 4_241_241,
                    Conditions = new SellConditions()
                    {
                        HaveChildPrescribers = true,
                        HaveChildOwners = true,
                        OwnersCount = 1000,
                        PrescribersCount = 151151,
                        Type = "Ыыыы",
                        YearInOwn = 2014
                    }
                },
                Reality = new Office()
                {
                    Access = "Свободный",
                    Address = "г. Тюмень ул.Тюмень д.52151",
                    Area = 1228,
                    Floor = 14,
                    Building = new Building()
                    {
                        BuildingYear = 2021,
                        CenterName = "ТРЦ Ыыыыы",
                        Class = "Первый классный",
                        HaveParking = true,
                        IsEquipment = true
                    },
                    Entry = "Общий",
                    FloorsCount = 525,
                    IsUse = true,
                    Name = "Фамилия",
                    RoomsCount = 6262,
                },
                Description = "ПиОСАНИЕ"
            },
            new Announcement
            {
                ConnectionType = "Словесная перепалка",
                CounterAgent = counterAgents[1],
                Deal = new Sell()
                {
                    Price = 4_241_241,
                    Conditions = new SellConditions()
                    {
                        HaveChildPrescribers = true,
                        HaveChildOwners = true,
                        OwnersCount = 25,
                        PrescribersCount = 124,
                        Type = "Ыыыы",
                        YearInOwn = 20000
                    }
                },
                Reality = new Office()
                {
                    Floor = 14,
                    Access = "Свободный",
                    Address = "г. Тюмень ул.Тюмень д.214у12",
                    Area = 44,
                    Building = new Building()
                    {
                        BuildingYear = 2021,
                        CenterName = "ТРЦ Ааааа",
                        Class = "Второй прекрасный",
                        HaveParking = true,
                        IsEquipment = false
                    },
                    Entry = "Общий",
                    FloorsCount = 214,
                    IsUse = false,
                    Name = "Имя",
                    RoomsCount = 421,
                },
                Description = "ОПиСАНИЕ"
            },
            new Announcement
            {
                ConnectionType = "Душевная",
                CounterAgent = counterAgents[0],
                Deal = new Rent()
                {
                    Price = double.Pi,
                    Conditions = new  RentConditions()
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
                Reality = new Flat()
                {
                    Address = "ул. ХИХИХИХА",
                    Building = new ApartmentHouse()
                    {
                        BuildingYear = 2022,
                        CeilingHeight = 252,
                        HaveGarbageChute = true,
                        HaveParking = true,
                        Infrastructures = ["Туалет", "Унитаз"],
                        IsSecurity = true,
                        IsGas = false,
                        Landscaping = ["Жёсткая зелень"],
                        Type = "Жёсткий",
                    },
                    Area = 1254125,
                    BalconyType = "Классный",
                    Floor = 25,
                    FloorsCount = 25,
                    IsFresh = true,
                    IsRepaired = true,
                    KitchenArea = 12421412
                }
            }
        ];
        
        dbContext.Announcements.AddRange(announcements);
        dbContext.SaveChanges();

        Review[] reviews =
        [
            new Review
            {
                DestinationId = Guid.Parse("31518932-1c49-4397-8b2d-63bab308fd12"),
                Author = counterAgents[0],
                Header = "Ужасно",
                Text = "Удали аккаунт пожалуйста и больше никогда его не создавай!",
                Rate = 1,
                ReviewDate = DateTime.UtcNow
            },
            new Review
            {
                DestinationId = counterAgents[0].Id,
                Author = counterAgents[1],
                Header = "Ужасно",
                Text = "Удали аккаунт пожалуйста и больше никогда его не создавай!",
                Rate = 1,
                ReviewDate = DateTime.UtcNow
            },
        ];
        
        dbContext.Reviews.AddRange(reviews);
        dbContext.SaveChanges();
        
        return services;
    }
}