FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SteakService.csproj", "SteakService/"]
RUN dotnet restore "SteakService/SteakService.csproj"
WORKDIR "/src/SteakService"
COPY . .
RUN dotnet build "SteakService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SteakService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "SteakService.dll" ]