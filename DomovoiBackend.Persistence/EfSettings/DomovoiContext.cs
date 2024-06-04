using System.Reflection;
using DomovoiBackend.Domain.Entities.Announcements;
using DomovoiBackend.Domain.Entities.ChatEntities;
using DomovoiBackend.Domain.Entities.Common;
using DomovoiBackend.Domain.Entities.CounterAgents;
using DomovoiBackend.Domain.Entities.CounterAgents.Types;
using DomovoiBackend.Domain.Entities.Deals;
using DomovoiBackend.Domain.Entities.Deals.Rents;
using DomovoiBackend.Domain.Entities.Deals.Sells;
using DomovoiBackend.Domain.Entities.Realities;
using DomovoiBackend.Domain.Entities.Realities.Areas;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings;
using DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types;
using DomovoiBackend.Domain.Entities.Realities.Garages;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types;
using DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes;
using Microsoft.EntityFrameworkCore;

namespace DomovoiBackend.Persistence.EfSettings;

/// <summary>
/// Контекст БД.
/// </summary>
public class DomovoiContext : DbContext
{
    public DomovoiContext(DbContextOptions<DomovoiContext> options) : base(options) { }
    
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<CounterAgent> CounterAgents { get; set; }
    public DbSet<PhysicalCounterAgent> PhysicalCounterAgents { get; set; }
    public DbSet<LegalCounterAgent> LegalCounterAgents { get; set; }
    public DbSet<Deal> Deals { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<RentConditions> RentConditions { get; set; }
    public DbSet<Sell> Sells { get; set; }
    public DbSet<SellConditions> SellConditions { get; set; }
    public DbSet<Reality> Realities { get; set; }
    public DbSet<Garage> Garages { get; set; }
    public DbSet<CommercialBuilding> CommercialBuildings { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Production> Productions { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<LivingBuilding> LivingBuildings { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Bathroom> Bathrooms { get; set; }
    public DbSet<HousePart> HouseParts { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Flat> Flats { get; set; }
    public DbSet<ApartmentHouse> ApartmentHouses { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}