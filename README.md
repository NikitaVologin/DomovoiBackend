| Адрес                                    | Название    |
|------------------------------------------|-------------|
| http://localhost:8080/swagger/index.html | swagger     |
| http://localhost:8080                    | Приложение  |
| http://localhost:5051                    | pgAdmin     |

pgAdmin:
1. Email: admin@admin.com
2. Password: 123

# 1. Регистрация и авторизация:
## 1.2. Создание нового пользователя:

<b>Endpoint:</b> /CounterAgent/{counterAgentType} [POST], где counterAgentType = ["Physical" или "Legal"];

<b>Основной запрос:</b>


```json
{
  "counterAgentInfo": {
    ...
  }
}
```

Варианты полей counterAgentInfo:

1. (При counterAgentType = "Physical"):
```json
{
  "counterAgentInfo": {
    "contactNumber": "string",
    "email": "string",
    "password": 0,
    "fio": "string",
    "passportData": "string"
  }
}
```
2. (При counterAgentType = "Legal"):
```json
{
  "counterAgentInfo": {
    "contactNumber": "string",
    "email": "string",
    "password": 0,
    "name": "string",
    "tin": "string",
    "trc": "string"
  }
}
```

<b>Ответ:</b> STRING GUID (Id контр-агента);

## 1.2. Получение пользователя по почте и паролю:

<b>Endpoint:</b> /CounterAgent/Login [POST]

<b>Запрос:</b>
```json
{
  "email": "string",
  "password": "string"
}
```

<b>Ответы</b>:
1. Если type = "Physical":
```json
{
  "counterAgentType": "Physical",
  "fio": "string",
  "passportData": "string",
  "contactNumber": "string",
  "email": "string",
  "password": "string"
}
```
2. Если type = "Legal":
```json
{
  "counterAgentType": "Legal",
  "trc": "string",
  "tin": "string",
  "name":  "string",
  "contactNumber": "string",
  "email": "string",
  "password": "string"
}
```