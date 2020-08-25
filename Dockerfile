# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY WebApi/ /WebApi/
COPY OrderManagement.Models/ /OrderManagement.Models/
WORKDIR '/WebApi/'
RUN dotnet restore OrderManagement.WebApi/


# copy everything else and build app
RUN dotnet publish OrderManagement.WebApi/ -c release -f netcoreapp3.1 -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "OrderManagement.WebApi.dll"]
