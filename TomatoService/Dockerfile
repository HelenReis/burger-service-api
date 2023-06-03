FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TomatoService.csproj", "TomatoService/"]
RUN dotnet restore "TomatoService/TomatoService.csproj"
WORKDIR "/src/TomatoService"
COPY . .
RUN dotnet build "TomatoService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TomatoService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "TomatoService.dll" ]