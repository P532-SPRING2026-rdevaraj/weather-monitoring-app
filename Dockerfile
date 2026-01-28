# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /app

# Copy project file and restore
COPY WeatherMonitoring.UI/WeatherMonitoring.UI.csproj WeatherMonitoring.UI/
RUN dotnet restore WeatherMonitoring.UI/WeatherMonitoring.UI.csproj

# Copy remaining source code
COPY . .

# Publish the application
RUN dotnet publish WeatherMonitoring.UI/WeatherMonitoring.UI.csproj \
    -c Release \
    -o /app/publish

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

COPY --from=builder /app/publish .

CMD ["dotnet", "WeatherMonitoring.UI.dll"]
