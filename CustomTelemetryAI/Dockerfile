FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CustomTelemetryAI/CustomTelemetryAI/CustomTelemetryAI.csproj", "CustomTelemetryAI/"]
RUN dotnet restore "CustomTelemetryAI/CustomTelemetryAI.csproj"
COPY . .
WORKDIR "/src/CustomTelemetryAI"
RUN dotnet build "CustomTelemetryAI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomTelemetryAI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomTelemetryAI.dll"]
