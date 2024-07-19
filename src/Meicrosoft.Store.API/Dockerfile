#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Meicrosoft.Store.API/Meicrosoft.Store.API.csproj", "src/Meicrosoft.Store.API/"]
COPY ["src/Meicrosoft.Store.IoC/Meicrosoft.Store.IoC.csproj", "src/Meicrosoft.Store.IoC/"]
COPY ["src/Meicrosoft.Store.Application/Meicrosoft.Store.Application.csproj", "src/Meicrosoft.Store.Application/"]
COPY ["src/Meicrosoft.Store.Domain/Meicrosoft.Store.Domain.csproj", "src/Meicrosoft.Store.Domain/"]
COPY ["src/Meicrosoft.Store.Infra/Meicrosoft.Store.Infra.csproj", "src/Meicrosoft.Store.Infra/"]
RUN dotnet restore "./src/Meicrosoft.Store.API/./Meicrosoft.Store.API.csproj"
COPY . .
WORKDIR "/src/src/Meicrosoft.Store.API"
RUN dotnet build "./Meicrosoft.Store.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Meicrosoft.Store.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meicrosoft.Store.API.dll"]