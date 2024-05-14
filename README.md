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


# 2. Тестирование.
## 2.1. Модульное тестирование.

### 2.1.1. Слой Application:

| CounterAgentService | Статус Покрытия      |
|---------------------|----------------------|
| Add (Регистрация)   | 100% ✅               |
| Login               | 100% ✅               |
| Update              | 0% (Функционала нет) |

| AnnouncementService | Статус Покрытия       |
|---------------------|-----------------------|
| Add                 | 100% ✅                |
| Get                 | 100% ✅                |
| Get Many            | 100% ✅                |
| Get с ограничениями | 0% (Новый функционал) |
| Update / Close      | 0% (Функционала нет)  |

### 2.2. Функциональное (end-to-end) тестирование:
<b>НЕОБХОДИМО:</b> ЗАПУЩЕННЫЙ DOCKER ENGINE!!! (ТЕСТИРОВАНИЕ ИДЁТ НА ОСНОВЕ ОБРАЗА POSTGRESQL)

<b>ВАЖНО:</B> КАЖДЫЙ ТЕСТ ДОЛЖЕН БЫТЬ ЗАПУЩЕН ПО ОТДЕЛЬНОСТИ (ЧТОБЫ НЕ СОЗДАВАТЬ ОШИБКИ-ТЕСТОВ)

КАЖДЫЙ ФУНКЦИОНАЛЬНЫЙ ТЕСТ НАЗЫВАЕТСЯ В ФОРМАТЕ <b>Api_{Name}</b>.

### 2.2.1. Endpoints  - Контрагенты
| Endpoint                           | Покрытие |
|------------------------------------|----------|
| [POST] /CounterAgent (Регистрация) | 100% ✅   |
| [POST] /CounterAgent/Login         | 100% ✅   |

### 2.2.2. Endpoints - Объявления
| Endpoint                                                         | Покрытие              |
|------------------------------------------------------------------|-----------------------|
| [POST] /Announcement/{RealityType}/{DealType}                    | 100% ✅                |
| [GET] /Announcement/take/{count}                                 | 100% ✅                |
| [GET] /Announcement/{id}                                         | 100% ✅                |
| [GET] /Announcement/take?fromIndex={fromIndex}&toIndex={toIndex} | 0% (Новый функционал) |




# 3. Информация об контейнерах.

| Адрес                                    | Название    |
|------------------------------------------|-------------|
| http://localhost:8181/swagger/index.html | swagger     |
| http://localhost:8181                    | Приложение  |
| http://localhost:5051                    | pgAdmin     |

pgAdmin:
1. Email: admin@admin.com
2. Password: 123

# 4. Информации для запросов/ответов:
## 4.1. Deals Information (Информация о сделках):
### 4.1.1. RentInformation ("dealType" = "Rell"):

```json
{
  "conditions": {
    "price": 0,
    "period": "string",
    "deposit": 0,
    "communalPays": 0,
    "prepay": 0,
    "facilities": "string",
    "withKids": false,
    "withAnimals": false,
    "canSmoke": false
  },
  "dealType": "string" // (В ЗАПРОСАХ, ГДЕ В ROUTE НЕТ ТИПА, НАПРИМЕР ПОЛУЧЕНИЕ ОБЪЯВЛЕНИЯ)
}
```
### 4.1.2. SellInformation ("dealType" = "Sell"):
```json
{
  "conditions": {
    "price": 0,
    "type": "string",
    "yearsInOwn": 0,
    "ownersCount": 0,
    "prescribersCount": 0,
    "haveChildOwners": false,
    "haveChildPrescribers": false
  },
  "dealType": "string" // (В ЗАПРОСАХ, ГДЕ В ROUTE НЕТ ТИПА, НАПРИМЕР ПОЛУЧЕНИЕ ОБЪЯВЛЕНИЯ)
}
```
## 4.2. CounterAgent Information(Информация о контр-агентах):

### 4.2.1 PhysicalCounterAgentInfo ("counterAgentType" = "Physical"):
```json
{
  "id": "guid",
  "contactNumber": "string",
  "fio": "string",
  "passportData": "string",
  "counterAgentType": "string"
}
```
### 4.2.2. LegalCounterAgentInfo ("counterAgentType" = "Legal")
```json
{
  "id": "guid",
  "contactNumber": "string",
  "name": "string",
  "tin": "string",
  "trc": "string"
}
```

## 4.3. Reality Information (Информация о недвижимостях):
### 4.3.1. Commercial Realities Information (Информация о коммерческих недвижимостях):

### 4.3.1.1. OfficeInformation ("realityType" = "Office"):
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

## 4.4. AnnouncementInformation:
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

# 5. Запросы.
# 5.1. Контр-агенты:

## 5.1.1. Создание нового контр-агента:
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

## 5.1.2. Логин:
Endpoint: [POST] /CounterAgent/Login

Тело запроса:
```json
{
  "email": "string",
  "password": "string"
}
```
Конкретный Information (перечислены выше);

# 5.2. Объявления.

## 5.2.1. Получить объявление по Id
Endpoint [GET] /Announcement/{id} (где id - guid)

Ответ: AnnouncementInfo (указано выше).

## 5.2.2. Получить первые N обявлений:
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

## 5.2.3. Загрузить объявление.
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
  "counterAgentId": "GUID"
}
```

Ответ: Guid добавленного объявления.