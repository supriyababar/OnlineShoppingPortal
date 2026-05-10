# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the project file
COPY ["ProductCatalogService.csproj", ""]

# Restore dependencies
RUN dotnet restore "ProductCatalogService.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build "ProductCatalogService.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ProductCatalogService.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port
EXPOSE 5004
ENV ASPNETCORE_URLS=http://+:5004

# Run the application
ENTRYPOINT ["dotnet", "ProductCatalogService.dll"]
