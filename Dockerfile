# Main API Gateway Dockerfile
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the API Gateway project file
COPY ["ApiGateway/ApiGateway/ApiGateway.csproj", "ApiGateway/ApiGateway/"]

# Restore dependencies
RUN dotnet restore "ApiGateway/ApiGateway/ApiGateway.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build "ApiGateway/ApiGateway/ApiGateway.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ApiGateway/ApiGateway/ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port
EXPOSE 8000
ENV ASPNETCORE_URLS=http://+:8000

# Run the application
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
