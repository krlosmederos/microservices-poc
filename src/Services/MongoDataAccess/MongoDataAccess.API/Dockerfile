# More info https://github.com/dotnet/dotnet-docker/tree/master/samples
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS="https://*:443;http://*:80"
EXPOSE 80
EXPOSE 443


COPY ["Services/MongoDataAccess/MongoDataAccess.API/MongoDataAccess.API.csproj", "src/"]

RUN dotnet restore src/MongoDataAccess.API.csproj

COPY Services/MongoDataAccess/MongoDataAccess.API/ /src

WORKDIR /src
RUN dotnet build --no-restore -c $BUILD_CONFIGURATION

RUN dotnet publish -c $BUILD_CONFIGURATION --output ../publish

WORKDIR /publish
ENTRYPOINT ["dotnet", "MongoDataAccess.API.dll"]