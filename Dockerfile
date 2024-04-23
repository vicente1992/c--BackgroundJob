FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BackgroundJob.Cron/BackgroundJob.Cron.csproj", "BackgroundJob.Cron/"]
RUN dotnet restore "BackgroundJob.Cron/BackgroundJob.Cron.csproj"
COPY . .
WORKDIR "/src/BackgroundJob.Cron"
RUN dotnet build "BackgroundJob.Cron.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackgroundJob.Cron.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackgroundJob.Cron.dll"]
