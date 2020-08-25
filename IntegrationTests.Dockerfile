# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY WebApi/ /WebApi/
COPY OrderManagement.Models/ /OrderManagement.Models/
WORKDIR '/WebApi/'
RUN dotnet restore OrderManagement.WebApi.IntegrationTests/


# copy everything else and run the test 
RUN dotnet test OrderManagement.WebApi.IntegrationTests/  -f netcoreapp3.1 --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "OrderManagement.WebApi.test.dll"]
