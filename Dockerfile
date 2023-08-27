# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY *.sln .
COPY Directory.Build.props .
COPY src/Panda.Api/*.csproj ./src/Panda.Api/
COPY src/Panda.Core/*.csproj ./src/Panda.Core/
COPY src/Panda.Infrastructure/*.csproj ./src/Panda.Infrastructure/
COPY src/Panda.Persistence/*.csproj ./src/Panda.Persistence/

COPY test/Panda.Core.Bench/*.csproj ./test/Panda.Core.Bench/
COPY test/Panda.Core.Tests/*.csproj ./test/Panda.Core.Tests/

RUN dotnet restore 

COPY . .
RUN dotnet publish -c Release --no-restore -o /app/out/Panda.Api

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

COPY --from=build /app/out/Panda.Api ./

ENTRYPOINT ["dotnet", "Panda.Api.dll"]