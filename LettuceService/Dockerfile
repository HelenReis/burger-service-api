FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LettuceService.csproj", "LettuceService/"]
RUN dotnet restore "LettuceService/LettuceService.csproj"
WORKDIR "/src/LettuceService"
COPY . .
RUN dotnet build "LettuceService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LettuceService.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "LettuceService.dll" ]