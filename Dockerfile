FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ./*.props ./

COPY ["src/Gateway/Gateway.csproj", "src/Gateway/"]
COPY ["src/Application/Gateway.Application/Gateway.Application.csproj", "src/Application/Gateway.Application/"]
COPY ["src/Application/Gateway.Application.Contracts/Gateway.Application.Contracts.csproj", "src/Application/Gateway.Application.Contracts/"]
COPY ["src/Application/Gateway.Application.Models/Gateway.Application.Models.csproj", "src/Application/Gateway.Application.Models/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Presentation/Grpc/Grpc.csproj", "src/Presentation/Grpc/"]

RUN dotnet restore "src/Gateway/Gateway.csproj"

COPY . .
WORKDIR "/src/src/Gateway"
RUN dotnet build "Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Gateway.dll"]
