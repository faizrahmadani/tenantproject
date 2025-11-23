# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only csproj first
COPY TenantProject/*.csproj TenantProject/
RUN dotnet restore "TenantProject/TenantProject.csproj"

# Copy all source code
COPY . .

# Build
WORKDIR "/src/TenantProject"
RUN dotnet build "TenantProject.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "TenantProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy publish result
COPY --from=publish /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "TenantProject.dll"]
