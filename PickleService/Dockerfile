FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PickleService.csproj", "PickleService/"]
RUN dotnet restore "PickleService/PickleService.csproj"
WORKDIR "/src/PickleService"
COPY . .
RUN dotnet build "PickleService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PickleService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "PickleService.dll" ]