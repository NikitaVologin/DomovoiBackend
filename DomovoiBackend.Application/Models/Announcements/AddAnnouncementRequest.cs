using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Deals.SellInformation;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities;
using DomovoiBackend.Application.Models.Announcements.RequestInfos.Realities.CommercialRealities.TypesRequest;

namespace DomovoiBackend.Application.Models.Announcements;

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

public class AddAnnouncementRequest
{
    public string Description { get; set; }
    public string ConnectionType { get; set; }
    public DealRequestInfo DealInfo { get; set; }
    public RealityRequestInfo RealityInfo { get; set; }
    public Guid CounterAgentId { get; set; }
}