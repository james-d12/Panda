#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /panda
COPY ["Directory.Build.props", "."]
COPY ["src/Panda.Api/Panda.Api.csproj", "src/Panda.Api/"]
COPY ["src/Panda.Core/Panda.Core.csproj", "src/Panda.Core/"]
COPY ["src/Panda.Persistence/Panda.Persistence.csproj", "src/Panda.Persistence/"]
RUN dotnet restore "src/Panda.Api/Panda.Api.csproj"
COPY . .
WORKDIR "/panda/src/Panda.Api"
RUN dotnet build "Panda.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Panda.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Panda.Api.dll"]