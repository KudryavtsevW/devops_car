FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CarEmulator.csproj", "CarEmulator.csproj"]
RUN dotnet restore "CarEmulator.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "CarEmulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarEmulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarEmulator.dll"]
