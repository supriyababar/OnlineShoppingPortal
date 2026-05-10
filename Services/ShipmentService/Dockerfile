# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the project file
COPY ["ShipmentService.csproj", ""]

# Restore dependencies
RUN dotnet restore "ShipmentService.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build "ShipmentService.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ShipmentService.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port
EXPOSE 5005
ENV ASPNETCORE_URLS=http://+:5005

# Run the application
ENTRYPOINT ["dotnet", "ShipmentService.dll"]
