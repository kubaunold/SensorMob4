#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SensorMobCRUD/SensorMobCRUD.csproj", "SensorMobCRUD/"]
RUN dotnet restore "SensorMobCRUD/SensorMobCRUD.csproj"
COPY . .
WORKDIR "/src/SensorMobCRUD"
RUN dotnet build "SensorMobCRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensorMobCRUD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorMobCRUD.dll"]