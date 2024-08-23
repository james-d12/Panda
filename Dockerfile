# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.sln .
COPY src/**/*.csproj .src/
COPY Directory.Build.props .
COPY docker-compose.dcproj .
COPY src/Panda.Api/*.csproj ./src/Panda.Api/
COPY src/Panda.Core/*.csproj ./src/Panda.Core/
COPY src/Panda.Infrastructure/*.csproj ./src/Panda.Infrastructure/
COPY src/Panda.Persistence/*.csproj ./src/Panda.Persistence/
COPY src/Panda.Core.Unit.Tests/*.csproj ./src/Panda.Core.Unit.Tests/

RUN dotnet restore Panda.sln

COPY . .
RUN dotnet publish Panda.sln -c Release --no-restore -o /app/out/Panda.Api

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out/Panda.Api ./

ENTRYPOINT ["dotnet", "Panda.Api.dll"]