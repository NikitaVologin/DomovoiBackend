using DomovoiBackend.Application.Information.Deals;
using DomovoiBackend.Application.Information.Realities;
using Microsoft.AspNetCore.Http;

namespace DomovoiBackend.Application.Requests.Announcements;

/*
 * {
         "description": "string",
         "connectionType": "string",
         "dealInfo": {
           "sellConditionInfo": {
             "price": 0,
             "type": "string"
           },
           "sellFeaturesInfo": {
             "yearInOwn": 0,
             "ownersCount": 0,
             "prescribersCount": 0,
             "haveChildOwners": true,
             "haveChildPrescribers": true
           }
         },
         "realityInfo": {
           "area": 0,
           "type": "string",
           "floorsCount": 0,
           "entry": true,
           "address": "string",
           "isUse": true,
           "isAccess": true,
           "building": {
             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
             "class": "string",
             "buildingYear": 0,
             "centerName": "string",
             "haveParking": true,
             "isEquipment": true
           },
           "name": "string",
           "roomsCount": 0
         },
         "counterAgentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
       }
 */


/// <summary>
/// Запрос создания объявления.
/// </summary>
public class AddAnnouncementRequest
{
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Тип связи.
    /// </summary>
    public string ConnectionType { get; set; }
    
    /// <summary>
    /// Информация о сделке.
    /// </summary>
    public DealInformation DealInfo { get; set; }
    
    /// <summary>
    /// Информация о недвижимости.
    /// </summary>
    public RealityInformation RealityInfo { get; set; }
    
    /// <summary>
    /// Id Контр-агента.
    /// </summary>
    public Guid CounterAgentId { get; set; }
    
    public IFormFile[] Pictures { get; set; }
}