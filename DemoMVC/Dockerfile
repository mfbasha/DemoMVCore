FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5156

ENV ASPNETCORE_URLS=http://+:5156

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["DemoMVC/DemoMVC.csproj", "DemoMVC/"]
RUN dotnet restore "DemoMVC/DemoMVC.csproj"
COPY . .
WORKDIR "/src/DemoMVC"
RUN dotnet build "DemoMVC.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "DemoMVC.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMVC.dll"]
