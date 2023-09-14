#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EventScheduling.Api/EventScheduling.Api.csproj", "EventScheduling.Api/"]
COPY ["EventScheduling.Application/EventScheduling.Application.csproj", "EventScheduling.Application/"]
COPY ["EventScheduling.Domain/EventScheduling.Domain.csproj", "EventScheduling.Domain/"]
COPY ["EventScheduling.Infrastructure/EventScheduling.Infrastructure.csproj", "EventScheduling.Infrastructure/"]
RUN dotnet restore "EventScheduling.Api/EventScheduling.Api.csproj"
COPY . .
WORKDIR "/src/EventScheduling.Api"
RUN dotnet build "EventScheduling.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventScheduling.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventScheduling.Api.dll"]