FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BaconService.csproj", "BaconService/"]
RUN dotnet restore "BaconService/BaconService.csproj"
WORKDIR "/src/BaconService"
COPY . .
RUN dotnet build "BaconService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaconService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "BaconService.dll" ]