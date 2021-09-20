#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SJERP.API/SJERP.API.csproj", "src/SJERP.API/"]
RUN dotnet restore "src/SJERP.API/SJERP.API.csproj"
COPY . .
WORKDIR "/src/src/SJERP.API"
RUN dotnet build "SJERP.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SJERP.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SJERP.API.dll"]