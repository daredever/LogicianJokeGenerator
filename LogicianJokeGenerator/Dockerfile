FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LogicianJokeGenerator/LogicianJokeGenerator.csproj", "LogicianJokeGenerator/"]
RUN dotnet restore "LogicianJokeGenerator/LogicianJokeGenerator.csproj"
COPY . .
WORKDIR "/src/LogicianJokeGenerator"
RUN dotnet build "LogicianJokeGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogicianJokeGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogicianJokeGenerator.dll"]