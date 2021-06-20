#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Source/CableCarDubrovnik.Web/CableCarDubrovnik.Web.csproj", "Source/CableCarDubrovnik.Web/"]
COPY ["Source/MarioTravel.Core/MarioTravel.Core.csproj", "Source/MarioTravel.Core/"]
RUN dotnet restore "Source/CableCarDubrovnik.Web/CableCarDubrovnik.Web.csproj"
COPY . .
WORKDIR "/src/Source/CableCarDubrovnik.Web"
RUN dotnet build "CableCarDubrovnik.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CableCarDubrovnik.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CableCarDubrovnik.Web.dll"]