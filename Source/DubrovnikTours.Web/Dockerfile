#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Source/DubrovnikTours.Web/DubrovnikTours.Web.csproj", "Source/DubrovnikTours.Web/"]
COPY ["Source/MarioTravel.Core/MarioTravel.Core.csproj", "Source/MarioTravel.Core/"]
RUN dotnet restore "Source/DubrovnikTours.Web/DubrovnikTours.Web.csproj"
COPY . .
WORKDIR "/src/Source/DubrovnikTours.Web"
RUN dotnet build "DubrovnikTours.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DubrovnikTours.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DubrovnikTours.Web.dll"]