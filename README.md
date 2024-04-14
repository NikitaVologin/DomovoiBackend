# 1. Таблица реализованного и в процессе (основные действия):

| Сущность                               | XML-Документация | Response-Request Infos | Конфигурация БД |
|----------------------------------------|------------------|------------------------|-----------------|
| Контр-Агенты                           |                  |                        |                 |
| Физическое лицо (PhysicalCounterAgent) | Done             | Done                   | Done            |
| Юридическое лицо (LegalCounterAgent)   | Done             | Done                   | Done            |
| Сделки                                 |                  |                        |
| Аренда (Rent)                          | Done             | Done                   | Done            |
| Условия Аренды (RentConditions)        | Done             | Done                   | Done            |
| Правила Аренды (RentRules)             | Done             | Done                   | Done            |
| Продажа (Sell)                         | Done             | Done                   | Done            |
| Условия продажи (SellConditions)       | Done             | Done                   | Done            |
| Описание Продажи (SellFeatures)        | Done             | Done                   | Done            | 
| Коммерческая недвижимость              |                  |                        |
| Офис                                   | Done             | Done                   | Done            |
| Жилая недвижимость                     |                  |                        | 
| Квартира                               | In-Process       | In-Process             | Done            |


# 2. Информация об контейнерах.

| Адрес                                    | Название    |
|------------------------------------------|-------------|
| http://localhost:8080/swagger/index.html | swagger     |
| http://localhost:8080                    | Приложение  |
| http://localhost:5051                    | pgAdmin     |

pgAdmin:
1. Email: admin@admin.com
2. Password: 123

# 3. Информации для запросов/ответов:
## 3.1. Deals Information (Информация о сделках):
### 3.1.1. RentInformation ("dealType" = "Rell"):

```json
{
  "rentConditions": {
    "price": 0,
    "period": "string",
    "deposit": 0,
    "communalPays": 0,
    "prepay": 0
  },
  "rentRules": {
    "facilities": "string",
    "withKids": false,
    "withAnimals": false,
    "canSmoke": false
  },
  "dealType": "string" // (В ЗАПРОСАХ, ГДЕ В ROUTE НЕТ ТИПА, НАПРИМЕР ПОЛУЧЕНИЕ ОБЪЯВЛЕНИЯ)
}
```
### 3.1.2. SellInformation ("dealType" = "Sell"):
```json
{
  "sellConditions": {
    "price": 0,
    "type": "string"
  },
  "sellFeatures": {
    "yearsInOwn": 0,
    "ownersCount": 0,
    "prescribersCount": 0,
    "haveChildOwners": false,
    "haveChildPrescribers": false
  },
  "dealType": "string" // (В ЗАПРОСАХ, ГДЕ В ROUTE НЕТ ТИПА, НАПРИМЕР ПОЛУЧЕНИЕ ОБЪЯВЛЕНИЯ)
}
```
## 3.2. CounterAgent Information(Информация о контр-агентах):

### 3.2.1 PhysicalCounterAgentInfo ("counterAgentType" = "Physical"):
```json
{
  "id": "guid",
  "contactNumber": "string",
  "fio": "string",
  "passportData": "string",
  "counterAgentType": "string"
}
```
### 3.2.2. LegalCounterAgentInfo ("counterAgentType" = "Legal")
```json
{
  "id": "guid",
  "contactNumber": "string",
  "name": "string",
  "tin": "string",
  "trc": "string"
}
```

## 3.3. Reality Information (Информация о недвижимостях):
### 3.3.1. Commercial Realities Information (Информация о коммерческих недвижимостях):

### 3.3.1.1. OfficeInformation ("realityType" = "Office"):
```json
{
  "area": 0,
  "floorsCount": 0,
  "entry": "string",
  "address": "string",
  "isUse": false,
  "access": "string",
  "building": {
    "class": "string",
    "buildingYear": 0,
    "centerName": "string",
    "haveParking": false,
    "isEquipment": false
  },
  "name": "string",
  "roomsCount": 0
}
```

## 3.4. AnnouncementInformation:
```json
{
  "id": "guid",
  "description": "string",
  "connectionType": "string",
  "dealInfo": {
    // Тело Конкретного Deal-Info.
  },
  "realityInfo": {
    // Тело Конкретного Reality.
  },
  "counterAgentInfo": {
    // Тело Конкретного Counter-Agent.
  }
}
```

# 4. Запросы.
# 4.1. Контр-агенты:

## 4.1.1. Создание нового контр-агента:
Endpoint: [POST] /CounterAgent/{counterAgentType} (типы перечислены выше вместе с информацией).

Тело запроса:
```json
{
  "email": "string",
  "password": "string"
}
```

Ответ:
Конкретный Information (перечислены выше);

## 4.1.2. Логин:
Endpoint: [POST] /CounterAgent/Login

Тело запроса:
```json
{
  "email": "string",
  "password": "string"
}
```
Конкретный Information (перечислены выше);

# 4.2. Объявления.

## 4.2.1. Получить объявление по Id
Endpoint [GET] /Announcement/{id} (где id - guid)

Ответ: AnnouncementInfo (указано выше).

## 4.2.2. Получить первые N обявлений:
Endpoint [GET] /Announcement/take/{count} (где count = N)

Ответ:
```json
{
  "announcementInformation": [ {
      // Конкретный announcementInformation
    }
  ]
}
```

## 4.2.3. Загрузить объявление.
Endpoint [POST] /Announcement/{realityType}/{dealType} (Типы перечислены выше вместе с Info);

Запрос:
```json
{
  "description": "string",
  "connectionType": "string",
  "dealInfo": {
    // Тело Конкретного Deal-Info.
  },
  "realityInfo": {
    // Тело Конкретного Reality.
  },
  "counterAgentInfo": {
    // Тело Конкретного Counter-Agent.
  }
}
```

Ответ: Guid добавленного объявления.