
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["SmartStock.ConsoleApp/SmartStock.ConsoleApp.csproj", "SmartStock.ConsoleApp/"]
COPY ["SmartStock.Core/SmartStock.Core.csproj", "SmartStock.Core/"]

RUN dotnet restore "SmartStock.ConsoleApp/SmartStock.ConsoleApp.csproj"

COPY . .

WORKDIR "/src/SmartStock.ConsoleApp"

RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .


ENTRYPOINT ["dotnet", "SmartStock.ConsoleApp.dll"]
