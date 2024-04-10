FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DomovoiBackend.API/DomovoiBackend.API.csproj", "DomovoiBackend.API/"]
COPY ["DomovoiBackend.Application/DomovoiBackend.Application.csproj", "DomovoiBackend.Application/"]
COPY ["DomovoiBackend.Domain/DomovoiBackend.Domain.csproj", "DomovoiBackend.Domain/"]
COPY ["DomovoiBackend.Persistence/DomovoiBackend.Persistence.csproj", "DomovoiBackend.Persistence/"]
RUN dotnet restore "DomovoiBackend.API/DomovoiBackend.API.csproj"
COPY . .
WORKDIR "/src/DomovoiBackend.API"
RUN dotnet build "DomovoiBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DomovoiBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DomovoiBackend.API.dll"]
