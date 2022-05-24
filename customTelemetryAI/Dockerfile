FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["customTelemetryAI/customTelemetryAI.csproj", "customTelemetryAI/"]
RUN dotnet restore "customTelemetryAI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "customTelemetryAI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "customTelemetryAI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "customTelemetryAI.dll"]
