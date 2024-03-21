using DomovoiBackend.Domain.Factories.CommercialBuildingsFactories.Infos;
using DomovoiBackend.Domain.Factories.RealityFactories.Factories;

var RealityFactory = new RealityFactory();

var warehouseInfo = new WarehouseBuildingInfo(15, "w", 5, true, "s", true, true, null, true);

Console.WriteLine(RealityFactory.GenerateReality(warehouseInfo).Id);